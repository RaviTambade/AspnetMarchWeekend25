using System.Text;
using System.Text.Json;
using WebAppMVC.Entities;

namespace WebAppMVC.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() { }

        public Task AddCustomerAsync(Customer customer)
        {


            HttpClient client = new HttpClient();
            // Serialize the Customer object into JSON content
            var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("http://localhost:5266/api/customers/", jsonContent).Result;
            if (response.IsSuccessStatusCode)
            {
                // Optionally, you can handle the response if needed
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a Customer object
                var createdCustomer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new Exception("Failed to add the customer.");
            }
            return Task.CompletedTask;

        }

        public Task DeleteCustomerAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync($"http://localhost:5266/api/customers/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                // Optionally, you can handle the response if needed
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a Customer object
                var deletedCustomer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new Exception("Failed to delete the customer.");
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {

            // Example API endpoint for testing

            //https://jsonplaceholder.typicode.com/posts

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://localhost:5266/api/customers/");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of Customer objects
                var customers = JsonSerializer.Deserialize<List<Customer>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return customers;

            }
            else
            {
                return new List<Customer>();
            }


        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync($"http://localhost:5266/api/customers/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a list of Customer objects
                var customer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return customer;
            }
            else
            {
                return new Customer();
            }

        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();

            // Serialize the Customer object into JSON content
            var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync($"http://localhost:5266/api/customers/{customer.Id}", jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                // Optionally, you can handle the response if needed
                var result = response.Content.ReadAsStringAsync().Result;
                // Deserialize the JSON response into a Customer object
                var updatedCustomer = JsonSerializer.Deserialize<Customer>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new Exception("Failed to update the customer.");

            }

        }

    }
}