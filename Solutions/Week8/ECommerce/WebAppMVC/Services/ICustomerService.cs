

using WebAppMVC.Entities;
namespace WebAppMVC.Services
{
    public interface ICustomerService
    {
        //CRUD Operations
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
