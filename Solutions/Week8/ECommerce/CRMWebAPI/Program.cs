using CRMLib;
using CRMLib.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/api/customers", () => {
    ICustomerService customerService = new CustomerService();
    List<Customer> customers = customerService.GetCustomers();
    return Results.Ok(customers);
});

app.MapGet("/api/customers/{id}", (int id) =>
{
    ICustomerService customerService = new CustomerService();
    List<Customer> customers = customerService.GetCustomers();
    var customer = customers.FirstOrDefault(p => p.Id == id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/api/customers", (Customer customer) =>
{
    ICustomerService customerService = new CustomerService();
    List<Customer> customers = customerService.GetCustomers();
     customer.Id = customers.Max(p => p.Id) + 1;
    customers.Add(customer);
    return Results.Created($"/products/{customer.Id}", customer);
});

app.MapPut("/api/customers/{id}", (int id, Customer updatedCustomer) =>
{
    ICustomerService customerService = new CustomerService();
    List<Customer> customers = customerService.GetCustomers();

    var customer = customers.FirstOrDefault(p => p.Id == id);
    if (customer is null)
        return Results.NotFound();

    customer.Name = updatedCustomer.Name;
    customer.Email = updatedCustomer.Email;
    return Results.Ok(customer);
});

app.MapDelete("/api/customers/{id}", (int id) =>
{
    ICustomerService customerService = new CustomerService();
    List<Customer> customers = customerService.GetCustomers();
    var customer = customers.FirstOrDefault(p => p.Id == id);
    if (customer is null)
        return Results.NotFound();
    customers.Remove(customer);
    return Results.NoContent();
});

app.Run();
