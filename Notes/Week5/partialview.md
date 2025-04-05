# Partial Views

In **ASP.NET Core**, partial views are used to break up a page into reusable components. These components are essentially small parts of a view that can be rendered inside other views. Partial views help in creating a more maintainable and modular UI. You can think of them like small, independent chunks of HTML that can be embedded within larger views.

Here's a basic guide on how to use partial views in **ASP.NET Core**:

### 1. **Create a Partial View**
To create a partial view, you need to add a new `.cshtml` file inside the **Views** folder (or a subfolder, depending on your organization).

For example:
- You might have a view for rendering a **user profile**, which could be included in various other views.

Create a new partial view under **Views/Shared** (or any folder as per your preference):

**`_UserProfile.cshtml`** (Note the underscore at the beginning, which is a convention for partial views):

```html
@model UserProfileViewModel

<div class="user-profile">
    <h3>@Model.Name</h3>
    <p>@Model.Email</p>
    <p>@Model.Age</p>
</div>
```

### 2. **Use Partial View in a Main View**
You can include the partial view in a parent view using the `@Html.Partial` or `@Html.RenderPartial` helpers.

Example:
**`Index.cshtml`**:

```html
@{
    ViewData["Title"] = "Home Page";
}

<h1>Welcome to the Home Page</h1>

<div>
    <h2>Featured User</h2>
    @Html.Partial("_UserProfile", Model.UserProfile)
</div>
```

- `@Html.Partial("_UserProfile", Model.UserProfile)` renders the `_UserProfile` partial view and passes the `Model.UserProfile` data to it.

### 3. **Rendering Partial Views Asynchronously**
In certain cases, you may want to render the partial view asynchronously (useful if it involves complex logic or data fetching).

```html
@await Html.PartialAsync("_UserProfile", Model.UserProfile)
```

This renders the partial view asynchronously, which can improve performance if the rendering involves an expensive operation (like querying a database).

### 4. **Passing Data to Partial Views**
Partial views are usually rendered within the context of a parent view. You pass data from the parent view to the partial view.

In your **Controller** action:

```csharp
public IActionResult Index()
{
    var userProfile = new UserProfileViewModel
    {
        Name = "John Doe",
        Email = "john.doe@example.com",
        Age = 30
    };

    var viewModel = new HomeViewModel
    {
        UserProfile = userProfile
    };

    return View(viewModel);
}
```

In the **`Index.cshtml`**, pass the `UserProfile` to the partial view.

### 5. **Alternative: Rendering Partial Views with AJAX**
You can also use AJAX to load partial views dynamically. For instance, if you want to load the profile asynchronously without reloading the whole page, you could use **AJAX** in combination with **partial views**.

Here’s how you could do it:

- **JavaScript (AJAX)**:

```javascript
$(document).ready(function() {
    $.ajax({
        url: '/Home/LoadUserProfile',
        type: 'GET',
        success: function(result) {
            $('#user-profile-container').html(result);
        }
    });
});
```

- **Controller Method**:

```csharp
public IActionResult LoadUserProfile()
{
    var userProfile = new UserProfileViewModel
    {
        Name = "John Doe",
        Email = "john.doe@example.com",
        Age = 30
    };

    return PartialView("_UserProfile", userProfile);
}
```

Here, the partial view `_UserProfile` is rendered via AJAX when requested, and the result is injected into the `#user-profile-container` element on the page.

### 6. **RenderPartial vs Partial**
- `@Html.Partial` returns the HTML directly to the view.
- `@Html.RenderPartial` writes the HTML directly to the response stream, which might be more efficient if the partial view is being used multiple times in a single request.
  
However, the general recommendation is to use `@Html.Partial` unless performance profiling shows a need for `@Html.RenderPartial`.

### Summary:
- **Partial Views** allow you to modularize your views into smaller, reusable components.
- Use `@Html.Partial` or `@await Html.PartialAsync` to render a partial view in your main view.
- Data is passed from the parent view to the partial view through the model.
- You can also load partial views using **AJAX** for dynamic content loading.

Let me know if you need further clarification or additional examples!