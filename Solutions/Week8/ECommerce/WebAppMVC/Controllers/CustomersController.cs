using Microsoft.AspNetCore.Mvc;

using WebAppMVC.Entities;
using WebAppMVC.Services;
using WebAppMVC.Repositories;
using System.Collections.Generic;

namespace WebAppMVC.Controllers
{
    //MVC Controller
    public class CustomersController : Controller
    {

        //action method
        public IActionResult Index()
        {
            //Dependency Injection
            ICustomerService customerService = new CustomerSerice(new CustomerRepository());
            
            List<Customer> customers=customerService.GetCustomers();


            return View(customers);
        }
    }
}
