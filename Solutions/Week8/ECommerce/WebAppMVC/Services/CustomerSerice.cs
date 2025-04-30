using WebAppMVC.Entities;
using WebAppMVC.Repositories;
using System.Collections.Generic;

namespace WebAppMVC.Services
{
    public class CustomerSerice : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerSerice(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public Task AddCustomerAsync(Customer customer)
        {
            return _customerRepository.AddCustomerAsync(customer);
        }

        public Task DeleteCustomerAsync(int id)
        {
            return _customerRepository.DeleteCustomerAsync(id);

        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {

            return _customerRepository.GetAllCustomersAsync();
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return _customerRepository.GetCustomerByIdAsync(id);

        }

        public Task UpdateCustomerAsync(Customer customer)
        {

            return _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}
