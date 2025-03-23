ASP.NET Core is a powerful, cross-platform framework for building modern web applications, and Razor is a markup syntax used to embed C# code in web pages. Razor is often used with ASP.NET Core to build dynamic web pages with embedded C# logic.

Here are some key elements of Razor syntax when using ASP.NET Core:

### 1. **Basic Razor Syntax:**
   Razor syntax is denoted by `@` followed by C# code, making it easy to switch between HTML and C# code in a clean and readable way.

   **Example:**
   ```html
   <h1>@DateTime.Now</h1>
   ```

### 2. **Variables:**
   You can declare and use variables directly within Razor views.

   **Example:**
   ```html
   @var name = "John"
   <p>Hello, @name!</p>
   ```

### 3. **Conditionals:**
   Razor supports C# `if` statements directly in your markup.

   **Example:**
   ```html
   @if (DateTime.Now.Hour < 12)
   {
       <p>Good Morning</p>
   }
   else
   {
       <p>Good Afternoon</p>
   }
   ```

### 4. **Loops:**
   Razor supports C# loops like `for`, `foreach`, `while`.

   **Example:**
   ```html
   <ul>
       @foreach(var item in items)
       {
           <li>@item</li>
       }
   </ul>
   ```

### 5. **Rendering Partial Views:**
   You can render other views (partial views) within a Razor view.

   **Example:**
   ```html
   @Html.Partial("_MyPartialView")
   ```

### 6. **Expressions:**
   Razor is used to write expressions that get rendered as HTML output. These expressions can be anything from simple variables to more complex methods.

   **Example:**
   ```html
   <h2>@Model.Title</h2>
   ```

### 7. **HTML Helpers:**
   ASP.NET Core provides HTML helpers that are used to render forms and other HTML elements more easily.

   **Example:**
   ```html
   @Html.LabelFor(model => model.Name)
   @Html.EditorFor(model => model.Name)
   ```

### 8. **Forms and Model Binding:**
   Razor allows you to generate forms that automatically bind to a model.

   **Example:**
   ```html
   <form asp-action="SubmitForm" method="post">
       <input type="text" asp-for="Name" />
       <button type="submit">Submit</button>
   </form>
   ```

### 9. **Link Generation (Tag Helpers):**
   ASP.NET Core Razor uses tag helpers to generate links and forms that are HTML-compliant.

   **Example:**
   ```html
   <a asp-controller="Home" asp-action="Index">Home</a>
   ```

### 10. **Layout Pages:**
   Razor views can inherit layout pages, which allows you to define a consistent layout across multiple views.

   **Example (in a `_Layout.cshtml` file):**
   ```html
   <!DOCTYPE html>
   <html>
   <head>
       <title>@ViewData["Title"]</title>
   </head>
   <body>
       <header>
           <h1>My Application</h1>
       </header>
       <main>
           @RenderBody()
       </main>
   </body>
   </html>
   ```

   **Example (in a regular view):**
   ```html
   @{
       Layout = "_Layout";
   }
   <h2>Welcome to the page!</h2>
   ```

### 11. **Using `@{}` for Code Blocks:**
   You can use `@{}` for more complex C# logic in Razor views.

   **Example:**
   ```html
   @{
       var hour = DateTime.Now.Hour;
       string greeting = hour < 12 ? "Good Morning" : "Good Evening";
   }
   <p>@greeting</p>
   ```

### 12. **Using `@` in HTML Attributes:**
   Razor allows you to inject C# values into HTML attributes.

   **Example:**
   ```html
   <img src="@Url.Content("~/images/logo.png")" alt="Logo" />
   ```

### 13. **Razor Pages vs MVC:**
   - **Razor Pages:** Each Razor page is tied to a handler method (`OnGet`, `OnPost`, etc.).
   - **MVC:** Razor views are usually associated with controllers and actions.

### 14. **Tag Helpers:**
   Tag helpers allow you to add functionality to HTML tags in Razor views. They are HTML elements that have enhanced behavior through attributes.

   **Example:**
   ```html
   <form asp-action="SubmitForm">
       <input asp-for="Username" />
   </form>
   ```

### Summary:
Razor syntax is a great way to mix C# logic with HTML structure for dynamic content rendering. It makes it easy to build and maintain views in ASP.NET Core web applications. By using conditional logic, loops, tag helpers, and other Razor features, you can create interactive and dynamic web pages that interact with the backend logic of your application.