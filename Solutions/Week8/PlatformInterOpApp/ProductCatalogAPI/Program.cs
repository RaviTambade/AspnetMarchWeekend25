
using ProductCatalogAPI.Entities;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Product Catalog


var products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 999 },
    new Product { Id = 2, Name = "Phone", Price = 499 },
    new Product { Id = 3, Name = "TV", Price = 456 },
    new Product { Id = 4, Name = "Tablet", Price = 675 }
};

// API EndPoints have been  mapped to lambda functions
// 
app.MapGet("/api/products", () => products);
app.MapGet("/api/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});
app.MapPost("/api/products", (Product product) =>
{
    product.Id = products.Max(p => p.Id) + 1;
    products.Add(product);
    return Results.Created($"/products/{product.Id}", product);
});
app.MapPut("/api/products/{id}", (int id, Product updatedProduct) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null)
        return Results.NotFound();

    product.Name = updatedProduct.Name;
    product.Price = updatedProduct.Price;
    return Results.Ok(product);
});
app.MapDelete("/api/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null)
        return Results.NotFound();

    products.Remove(product);
    return Results.NoContent();
});
app.Run();