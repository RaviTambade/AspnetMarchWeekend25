//Web Application Startup
//This file is the entry point for the application.
//It configures the application and starts the server.

//Web Application Configuration
// steps for configuring the web application:
// 1. Create a new WebApplication instance.
// 2. Add services to the container.
// 3. Build the application.
// 4. Configure the HTTP request pipeline.



// HTTP request pipeline.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



//asp.net midlleware
app.UseRouting();
app.UseAuthorization();


//Route Mapping

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.Run();
