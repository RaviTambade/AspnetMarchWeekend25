
### Step-by-step approach:

1. Add a new `LoanApplication` model with properties like:

   * Applicant, LoanType, Bank, Timestamp (already present)
   * Status (Approved/Rejected)
   * Reason (why approved or rejected)

2. Update `AppDbContext` to include `DbSet<LoanApplication>`

3. Modify the consumer's received event handler:

   * Simulate approval logic
   * Save the application with decision in the database

---

### Code updates:

**1. Update `LoanApplication` model in `Loan.cs` (LoanBot.Core):**

```csharp
public class LoanApplication
{
    public int Id { get; set; }
    public string Applicant { get; set; } = string.Empty;
    public string LoanType { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = string.Empty;  // Approved / Rejected
    public string Reason { get; set; } = string.Empty;
}
```

---

**2. Add `DbSet` for LoanApplications in `AppDbContext.cs`:**

```csharp
public DbSet<LoanApplication> LoanApplications => Set<LoanApplication>();
```

---

**3. Modify `RabbitMQConsumer` to accept a scoped `AppDbContext` and save applications with simulated decision:**

* Since the current `RabbitMQConsumer` is not DI-friendly, we will change it to accept `AppDbContext` via constructor.

* Add simple approval logic like:

  * Approve if income > 50000 and CIBIL > 750 (we can simulate these in the message or make assumptions for demo).
  * Else reject.

**Here’s an updated version of the consumer class:**

```csharp
using LoanBot.Core.Models;
using LoanBot.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

public class RabbitMQConsumer
{
    private readonly IServiceScopeFactory _scopeFactory;

    public RabbitMQConsumer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void StartListening()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var appEvent = JsonConvert.DeserializeObject<LoanApplicationEvent>(message);

            Console.WriteLine($"[x] Received Loan Application: {appEvent?.Applicant} applied for {appEvent?.LoanType} at {appEvent?.Bank}.");

            // Simulate approval logic
            // For demo, randomly approve or reject, or based on some hardcoded rule
            var random = new Random();
            bool isApproved = random.Next(0, 2) == 1; // Random true or false

            var status = isApproved ? "Approved" : "Rejected";
            var reason = isApproved ? "Auto-approved based on scoring." : "Rejected due to policy constraints.";

            var loanApplication = new LoanApplication
            {
                Applicant = appEvent?.Applicant ?? "Unknown",
                LoanType = appEvent?.LoanType ?? "Unknown",
                Bank = appEvent?.Bank ?? "Unknown",
                Timestamp = appEvent?.Timestamp ?? DateTime.UtcNow,
                Status = status,
                Reason = reason
            };

            // Save to DB using a new scope
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.LoanApplications.Add(loanApplication);
                dbContext.SaveChanges();
            }

            Console.WriteLine($"[x] Application processed: Status = {status}");
        };

        channel.BasicConsume(queue: "loan_applications", autoAck: true, consumer: consumer);

        Console.WriteLine(" [*] Waiting for loan application events. Press [enter] to exit.");
        Console.ReadLine();
    }
}
```

---

### How to integrate this?

* Register `RabbitMQConsumer` as a singleton service in `Program.cs` with `IServiceScopeFactory`.

* Launch the consumer from the app or as a separate console app that has access to the DI container.

---



Absolutely! Here's a complete example that includes:

* **Program.cs** with DI setup for `AppDbContext`, `RabbitMQConsumer`, and launching the consumer in a background service.
* Updated **RabbitMQConsumer** class to run as a hosted background service using `IHostedService`.
* Using **EF Core InMemory** database for simplicity.

---

### 1. Updated `RabbitMQConsumer.cs` as a **background service**

```csharp
using LoanBot.Core.Models;
using LoanBot.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class RabbitMQConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private IConnection? _connection;
    private IModel? _channel;

    public RabbitMQConsumer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        InitializeRabbitMQ();
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var appEvent = JsonConvert.DeserializeObject<LoanApplicationEvent>(message);

            Console.WriteLine($"[x] Received Loan Application: {appEvent?.Applicant} applied for {appEvent?.LoanType} at {appEvent?.Bank}.");

            // Simulate approval logic
            var random = new Random();
            bool isApproved = random.Next(0, 2) == 1;

            var status = isApproved ? "Approved" : "Rejected";
            var reason = isApproved ? "Auto-approved based on scoring." : "Rejected due to policy constraints.";

            var loanApplication = new LoanApplication
            {
                Applicant = appEvent?.Applicant ?? "Unknown",
                LoanType = appEvent?.LoanType ?? "Unknown",
                Bank = appEvent?.Bank ?? "Unknown",
                Timestamp = appEvent?.Timestamp ?? DateTime.UtcNow,
                Status = status,
                Reason = reason
            };

            // Save to DB using a scoped service
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.LoanApplications.Add(loanApplication);
            await dbContext.SaveChangesAsync(stoppingToken);

            Console.WriteLine($"[x] Application processed: Status = {status}");
        };

        _channel.BasicConsume(queue: "loan_applications", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
```

---

### 2. Updated `AppDbContext.cs` (add `LoanApplications` DbSet)

```csharp
using LoanBot.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanBot.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<LoanApplication> LoanApplications => Set<LoanApplication>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, Type = "Home Loan", Bank = "Axis Bank", Interest = 7.8, ProcessingFee = 2000 },
                new Loan { Id = 2, Type = "Personal Loan", Bank = "HDFC", Interest = 10.5, ProcessingFee = 500 },
                new Loan { Id = 3, Type = "Car Loan", Bank = "ICICI", Interest = 9.2, ProcessingFee = 1000 }
            );
        }
    }
}
```

---

### 3. Full `Program.cs`

```csharp
using LoanBot.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with InMemory DB for demo
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("LoanDb"));

// Add controllers & swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register RabbitMQConsumer as a hosted service
builder.Services.AddHostedService<RabbitMQConsumer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
```

---

### How it works?

* The API part (controllers etc.) works as usual.
* The `RabbitMQConsumer` runs **in the background** listening for loan application messages.
* When a message arrives, it processes and saves approval status to the database.
* You can extend APIs to fetch the loan application status from the database.

---

Would you like me to help you add a controller to **retrieve processed loan applications** next?

Got it! Here's a simple controller to **retrieve processed loan applications** from the database:

---

### 1. Add `LoanApplicationsController.cs` in `LoanBot.Api.Controllers`

```csharp
using LoanBot.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoanApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanApplications
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _context.LoanApplications
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();

            return Ok(applications);
        }

        // GET: api/LoanApplications/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _context.LoanApplications.FindAsync(id);

            if (application == null)
                return NotFound();

            return Ok(application);
        }
    }
}
```

---

### 2. Sample JSON response for GET `/api/LoanApplications`

```json
[
  {
    "id": 1,
    "applicant": "John Doe",
    "loanType": "Home Loan",
    "bank": "Axis Bank",
    "timestamp": "2025-06-07T05:50:12.345Z",
    "status": "Approved",
    "reason": "Auto-approved based on scoring."
  },
  {
    "id": 2,
    "applicant": "Jane Smith",
    "loanType": "Car Loan",
    "bank": "ICICI",
    "timestamp": "2025-06-07T05:52:33.210Z",
    "status": "Rejected",
    "reason": "Rejected due to policy constraints."
  }
]
```

---

### How to test?

* Run your app.
* Send loan application events via `/api/Loans/apply`.
* The consumer processes events in the background.
* Then query `/api/LoanApplications` to see processed results.

---

If you want, I can help you write Postman collections or sample client code to test this API!

Here’s how you can test the **LoanBot API** using either:

---

## ✅ Option 1: 🧪 Postman Collection (Manual or Import)

### 📁 Postman Collection JSON

```json
{
  "info": {
    "name": "LoanBot API",
    "_postman_id": "abcd1234-loanbot-collection",
    "description": "Test collection for LoanBot API with RabbitMQ event-based workflow",
    "schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
  },
  "item": [
    {
      "name": "Get All Loans",
      "request": {
        "method": "GET",
        "header": [],
        "url": { "raw": "http://localhost:5000/api/loans", "protocol": "http", "host": ["localhost"], "port": "5000", "path": ["api", "loans"] }
      }
    },
    {
      "name": "Check Eligibility",
      "request": {
        "method": "POST",
        "header": [{ "key": "Content-Type", "value": "application/json" }],
        "body": {
          "mode": "raw",
          "raw": "{\n  \"age\": 28,\n  \"income\": 40000,\n  \"cibilScore\": 720,\n  \"location\": \"Pune\"\n}"
        },
        "url": { "raw": "http://localhost:5000/api/loans/eligibility/check", "protocol": "http", "host": ["localhost"], "port": "5000", "path": ["api", "loans", "eligibility", "check"] }
      }
    },
    {
      "name": "Apply for Loan",
      "request": {
        "method": "POST",
        "header": [{ "key": "Content-Type", "value": "application/json" }],
        "body": {
          "mode": "raw",
          "raw": "{\n  \"applicant\": \"Ravi Tambade\",\n  \"loanType\": \"Home Loan\",\n  \"bank\": \"Axis Bank\",\n  \"timestamp\": \"2025-06-07T06:00:00Z\"\n}"
        },
        "url": { "raw": "http://localhost:5000/api/loans/apply", "protocol": "http", "host": ["localhost"], "port": "5000", "path": ["api", "loans", "apply"] }
      }
    },
    {
      "name": "Get All Processed Applications",
      "request": {
        "method": "GET",
        "header": [],
        "url": { "raw": "http://localhost:5000/api/LoanApplications", "protocol": "http", "host": ["localhost"], "port": "5000", "path": ["api", "LoanApplications"] }
      }
    }
  ]
}
```

---

## ✅ Option 2: 🖥️ Sample C# Console Client (for programmatic testing)

```csharp
using System.Net.Http.Json;

var baseUrl = "http://localhost:5000/api";

var client = new HttpClient();

// 1. Apply for Loan
var applyResponse = await client.PostAsJsonAsync($"{baseUrl}/loans/apply", new
{
    applicant = "Ravi Tambade",
    loanType = "Car Loan",
    bank = "ICICI",
    timestamp = DateTime.UtcNow
});
Console.WriteLine(await applyResponse.Content.ReadAsStringAsync());

// Wait 3-5 seconds for RabbitMQ to process the event

await Task.Delay(5000);

// 2. Fetch All Processed Applications
var apps = await client.GetFromJsonAsync<List<LoanApplication>>($"{baseUrl}/LoanApplications");

foreach (var app in apps!)
{
    Console.WriteLine($"{app.Applicant} | {app.LoanType} | {app.Bank} | {app.Timestamp}");
}

public class LoanApplication
{
    public int Id { get; set; }
    public string Applicant { get; set; } = string.Empty;
    public string LoanType { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
```

---

## ✅ What to Check

* [x] Use `/api/loans` to fetch all loan types
* [x] Check eligibility using `/api/loans/eligibility/check`
* [x] Apply using `/api/loans/apply` → triggers RabbitMQ publisher
* [x] Run the `RabbitMQConsumer` to process the message
* [x] View processed loan applications using `/api/LoanApplications`

---

Would you like me to:

* Convert this Postman JSON into a `.postman_collection.json` download file?
* Add the consumer as a hosted background service next?
* Add status (`Approved/Rejected`) to `LoanApplication` for full workflow visibility?

