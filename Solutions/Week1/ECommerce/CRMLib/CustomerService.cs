using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMLib.Repositories;

namespace CRMLib.Services
{
    public class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
           List<Customer> customers = GetCustomers();
           customers.Add(customer);
            new CustomerIOManager().WriteCustomers(customers);

        }

        public void DeleteCustomer(int id)
        {
            List<Customer> customers = GetCustomers();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            customers.Remove(customer);
            new CustomerIOManager().WriteCustomers(customers);
        }

        public List<Customer> GetCustomers()
        {
            return new CustomerIOManager().ReadCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {

            List<Customer> customers = GetCustomers();
            Customer customerToUpdate = customers.FirstOrDefault(c => c.Id == customer.Id);
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Email = customer.Email;
            new CustomerIOManager().WriteCustomers(customers);
        }
    }
}
