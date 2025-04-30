using WebAppMVC.Entities;
using System.Collections.Generic;
namespace WebAppMVC.Repositories
{
    public interface ICustomerRepository
    {
        //CRUD Operations
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
