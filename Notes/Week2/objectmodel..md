##  “The Blueprint of the Digital City – Object Model in .NET Core”

Let me take you on a journey to a place I call the **Digital City**. In this city, every building, person, vehicle, and interaction is made of code. And just like every structure in a real city follows a plan (blueprint), so does every software application.

Welcome to **.NET Core**, where the **Object Model** is the architectural blueprint of your digital city.

---

### 🏗️ Act 1: Designing the Blueprint – Classes

Imagine you're an architect designing houses. You don’t build each house by hand every time. Instead, you create a **blueprint**. In programming, this blueprint is called a **class**.

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}");
    }
}
```

This `Product` class is your master design. It doesn’t represent an actual product—**yet**.

---

### 🧱 Act 2: Building Real Objects – Instantiation

Now, based on your blueprint, you build an actual house.

In code, this is called **creating an object**:

```csharp
var product = new Product { Id = 1, Name = "Laptop", Price = 1500m };
product.DisplayDetails();
```

This is a real-life object in your application. You can interact with it. You can store it in memory. You can even pass it around.

Just like every person living in your city is unique, each object carries its own **state (data)** and **behavior (methods)**.

---

### 🏛️ Act 3: Government Rules – Encapsulation

In any well-managed city, rules protect how citizens behave. You don’t want people to break into banks by accident.

In .NET Core, we use **encapsulation** to protect data.

```csharp
public class BankAccount
{
    private decimal balance;

    public void Deposit(decimal amount)
    {
        if (amount > 0) balance += amount;
    }

    public decimal GetBalance() => balance;
}
```

No one can touch the `balance` directly—**only through allowed behaviors**. That's a safe system.

---

### 🔌 Act 4: Powering Many Homes – Inheritance and Interfaces

What if you want to build more types of buildings—**Electronics**, **Books**, **Clothing**—but they all start from a basic `Product`?

You **inherit** the base class:

```csharp
public class Electronics : Product
{
    public int WarrantyPeriod { get; set; }
}
```

And sometimes, you just want to say: “Any building that wants electricity must install a socket.” That’s an **interface**—a **contract**.

```csharp
public interface IDisplayable
{
    void DisplayDetails();
}
```

Now, any object that promises to be `IDisplayable` must have a `DisplayDetails()` method.

---

### 📚 Act 5: Libraries, Shops, and Data Banks – EF Core and MVC

In your digital city, the **data** must be stored somewhere—just like people store records in the town hall. Enter **Entity Framework Core**.

Here, classes are mapped directly to **database tables**:

```csharp
public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
```

Each time you create a `Product`, it becomes a new **row in a table**. EF Core does the hard lifting of SQL behind the scenes.

Now pair that with **ASP.NET Core MVC**:

* **Models**: Your domain entities (`Product`, `User`, `Order`)
* **Controllers**: City workers that fetch, update, and manage the flow of data
* **Views**: Shop displays or public dashboards showing product listings

```csharp
public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    public ProductController(ApplicationDbContext context) => _context = context;

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
}
```

---

### 🧺 Act 6: City Markets – Working with Collections

Of course, your shop doesn’t sell just one product. You have **collections**—lists, inventories, catalogs.

```csharp
var products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 1500m },
    new Product { Id = 2, Name = "Phone", Price = 800m }
};
```

.NET Core gives you `List<T>`, `Dictionary<TKey, TValue>`, and more to handle groups of objects just like city marketplaces manage groups of items.

---

### 🎯 Final Lesson: Why Object Model Matters

Without a well-structured **Object Model**, your application is like a chaotic city with no planning. But with it, you get:

* ✅ Reusability (through classes and inheritance)
* ✅ Maintainability (using interfaces and encapsulation)
* ✅ Simplicity in interaction (via EF Core and MVC)

---

### 🧠 Mentor’s Wisdom:

> “A good Object Model is not about writing a lot of code; it's about writing code that mirrors reality. Think like an architect, act like a craftsman, and build like a city planner.”

Whether you're building a to-do app or an enterprise system, your **Object Model** is your **foundation**. Get that right, and your city—your software—will thrive.

