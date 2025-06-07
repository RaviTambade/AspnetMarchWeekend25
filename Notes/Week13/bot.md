✅ The **GitHub starter template** for the **LoanBot API** is now ready.

### What's Included:

* ✅ `Loan` model with sample seed data
* ✅ In-Memory EF Core database
* ✅ Minimal ASP.NET Core Web API with `GET /api/loans` and `GET /api/loans/{id}`
* ✅ Swagger enabled for testing

---

### 🔧 Next Steps You Can Add:

1. `POST /api/eligibility/check` — loan matching logic
2. `POST /api/loans/compare` — score & rank results
3. `RabbitMQ` or `gRPC` for inter-service communication
4. `OAuth2/JWT` security layer

Would you like me to:

* Help you add the **Eligibility engine logic**?
* Integrate **RabbitMQ for loan application events**?
* Or set up **Docker + GitHub Actions for deployment**?

Let me know how you'd like to continue!



✅ **Eligibility engine logic added!**

Now your API supports:

* `POST /api/loans/eligibility/check` — to evaluate user's profile and return eligible loans with reasons.

---

### 👨‍💻 Example Request:

```json
POST /api/loans/eligibility/check
Content-Type: application/json

{
  "age": 30,
  "income": 40000,
  "cibilScore": 720,
  "location": "Pune"
}
```

### ✅ Response:

```json
[
  {
    "loan": {
      "id": 1,
      "type": "Home Loan",
      "bank": "Axis Bank",
      "interest": 7.8,
      "processingFee": 2000
    },
    "reason": "Eligible based on good CIBIL and income."
  },
  ...
]
```

---

Would you like to:

* Add **RabbitMQ** for loan application event publishing next?
* Or include a **loan comparison API** to rank offers?

Let’s build it together!


✅ **RabbitMQ integration added!**

Your API now supports event publishing for loan applications via:

### 🔄 New API Endpoint

```http
POST /api/loans/apply
```

### 📦 Example Request

```json
{
  "applicant": "Tejas Kulkarni",
  "loanType": "Home Loan",
  "bank": "Axis Bank"
}
```

➡️ This will publish a message to the `loan_applications` queue on RabbitMQ.

---

Would you like to:

* Add a **RabbitMQ consumer** to process loan applications?
* Or store the application in a database for review?



✅ **RabbitMQ consumer added!**

You can now process loan applications by running the consumer with:

```csharp
new RabbitMQConsumer().StartListening();
```

It logs every loan application received from the queue.

Would you like to:

* Save processed applications to a database?
* Simulate auto-approval or rejection logic in the consumer?


✅ Done! The RabbitMQ consumer now saves received loan application events into the `LoanApplications` table in the in-memory database.

Would you like to:

* Add an API endpoint to retrieve saved loan applications?
* Seed more realistic loan data?
* Deploy this using Docker for portability?

Let me know how you want to evolve this project!

// LoanBot API - Starter Template (ASP.NET Core 8)
// Project Structure:
// - LoanBot.Api (Web API Project)
// - LoanBot.Core (Business Models & Interfaces)
// - LoanBot.Infrastructure (EF Core + Seed Data)
// - RabbitMQ integration for LoanApplication events (Publisher + Consumer)

// -----------------------------
// File: Loan.cs (in LoanBot.Core)
namespace LoanBot.Core.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public double Interest { get; set; }
        public double ProcessingFee { get; set; }
    }

    public class UserProfile
    {
        public int Age { get; set; }
        public double Income { get; set; }
        public double CibilScore { get; set; }
        public string Location { get; set; } = string.Empty;
    }

    public class EligibilityResult
    {
        public Loan Loan { get; set; }
        public string Reason { get; set; } = string.Empty;
    }

    public class LoanApplicationEvent
    {
        public string Applicant { get; set; } = string.Empty;
        public string LoanType { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class LoanApplication
    {
        public int Id { get; set; }
        public string Applicant { get; set; } = string.Empty;
        public string LoanType { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}

// -----------------------------
// File: AppDbContext.cs (in LoanBot.Infrastructure)
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

// -----------------------------
// File: RabbitMQPublisher.cs (in LoanBot.Infrastructure)
using LoanBot.Core.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace LoanBot.Infrastructure
{
    public class RabbitMQPublisher
    {
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
        }

        public void Publish(LoanApplicationEvent appEvent)
        {
            var message = JsonConvert.SerializeObject(appEvent);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "loan_applications", basicProperties: null, body: body);
        }
    }

    public class RabbitMQConsumer
    {
        private readonly AppDbContext _context;

        public RabbitMQConsumer(AppDbContext context)
        {
            _context = context;
        }

        public void StartListening()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var appEvent = JsonConvert.DeserializeObject<LoanApplicationEvent>(message);

                if (appEvent != null)
                {
                    var application = new LoanApplication
                    {
                        Applicant = appEvent.Applicant,
                        LoanType = appEvent.LoanType,
                        Bank = appEvent.Bank,
                        Timestamp = appEvent.Timestamp
                    };

                    _context.LoanApplications.Add(application);
                    _context.SaveChanges();
                    Console.WriteLine($"[✔] Application saved for {application.Applicant}");
                }
            };

            channel.BasicConsume(queue: "loan_applications", autoAck: true, consumer: consumer);

            Console.WriteLine(" [*] Waiting for loan application events. Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

// -----------------------------
// File: LoansController.cs (in LoanBot.Api)
using LoanBot.Core.Models;
using LoanBot.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RabbitMQPublisher _publisher;

        public LoansController(AppDbContext context)
        {
            _context = context;
            _publisher = new RabbitMQPublisher();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Loans.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            return loan == null ? NotFound() : Ok(loan);
        }

        [HttpPost("eligibility/check")]
        public async Task<IActionResult> CheckEligibility([FromBody] UserProfile profile)
        {
            var loans = await _context.Loans.ToListAsync();
            var eligible = new List<EligibilityResult>();

            foreach (var loan in loans)
            {
                if (profile.CibilScore >= 700 && profile.Income >= 30000)
                {
                    eligible.Add(new EligibilityResult
                    {
                        Loan = loan,
                        Reason = "Eligible based on good CIBIL and income."
                    });
                }
                else
                {
                    eligible.Add(new EligibilityResult
                    {
                        Loan = loan,
                        Reason = "Not eligible: insufficient CIBIL or income."
                    });
                }
            }

            return Ok(eligible);
        }

        [HttpPost("apply")]
        public IActionResult Apply([FromBody] LoanApplicationEvent appEvent)
        {
            _publisher.Publish(appEvent);
            return Ok(new { status = "Loan application event published successfully." });
        }
    }
}

// -----------------------------
// File: Program.cs (in LoanBot.Api)
using LoanBot.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("LoanDb"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
