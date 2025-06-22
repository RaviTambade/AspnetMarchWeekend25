### 🌼 TFL Session Story: Building a Shopping Cart using ASP.NET Core MVC

👨‍🏫 **Mentor's Opening**
"Imagine you're building a small flower shop website, where users can add flowers to their cart and check out later. But how do we remember their selection when they navigate across pages? That’s where **Session Management** comes into play."

### 🧱 **Application Building Blocks – Step-by-Step**

1. **Start with the Model (Entities)**
   * 🌸 We created a `Flower` class with properties like `Id`, `Name`, `UnitPrice`, `SalePrice`, etc.
  *  ✅ These properties are decorated with **attributes** like `[Display(Name = "Flower Name")]` and the class with `[Serializable]`.
  * 🔍 Attributes = Metadata (Just like annotations in Java)
  * 📦 Serialization helps save the object state (for sessions, files, or API transfer).

2. **Repositories & Services**

   * We followed the **Repository Pattern** – `IFlowerRepository`, `FlowerRepository`.
   * Then added **Service Layer** – `IFlowerService`, `FlowerService`.
   * 🎯 This delegation chain helps us keep things **modular**, testable, and maintainable.

3. **Dependency Injection (DI)**
   🔧 In `Program.cs`, we configured all services and repositories using `builder.Services.AddScoped<>()`.

4. **Session Configuration**
   🧠 Server-side session is configured via:

   ```csharp
   builder.Services.AddSession();
   app.UseSession();
   ```

   💡 The session ID is sent and retrieved via cookies. The client doesn’t store data—just a reference to session on the server.

5. **Controllers + Views**
   🛒 `ShoppingCartController` handles:

   * `AddToCart(int id)`
   * `RemoveFromCart(int id)`
   * `DisplayCart()`
     The controller uses session helpers to manage the cart.

6. **Session Helpers (Serialization)**
   🧰 We use utility methods like:

   * `SetObjectAsJson(ISession session, string key, object value)`
   * `GetObjectFromJson<T>(ISession session, string key)`
     🌟 These wrap around `session.SetString()` and `session.GetString()` with JSON serialization.

### 🧪 **Software Testing and the V-Model**

🧠 *“As a developer, you must think like a tester.”*

We introduced the **V-Model of Software Development**:

* **Left Side (Development)**:
  Requirement → Analysis → Design → Coding
* **Right Side (Testing)**:
  UAT ← System Testing ← Integration Testing ← Unit Testing

🧩 Every development activity has a corresponding testing activity:

* **Requirement ↔ UAT**
* **System Analysis ↔ System Testing**
* **Design ↔ Integration Testing**
* **Coding ↔ Unit Testing**

👨‍🔬 Developers should write tests for:

* Controllers
* Models
* Repositories
* Services
  🧪 Use unit tests to detect bugs early. Think like you're checking every part of an electronic circuit.

### 💼 **Industry Insight & Importance of Automation Testing**

* Manual testing is prone to errors due to human factors like stress and fatigue.
* Automation testing helps in reducing repetition and improving reliability.
* Product-based companies (e.g., Amazon, Siemens) require strong architecture and automated test coverage.
* SDLC (Software Development Life Cycle) and STLC (Software Testing Life Cycle) are **foundational** to enterprise development.

### 🧠 **Learning Reflection**

"Today, we didn’t just write code. We designed, structured, validated, and tested a **complete shopping cart application**. We saw how **models, controllers, views, and services** integrate, and how **sessions** help preserve user state."

💬 *“Great developers don’t just code—they **architect, test, and continuously improve.**”*
