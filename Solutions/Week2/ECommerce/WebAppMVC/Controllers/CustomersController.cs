using Microsoft.AspNetCore.Mvc;

using CRMLib.Services;
using CRMLib;

namespace WebAppMVC.Controllers
{
    //MVC Controller
    public class CustomersController : Controller
    {

        //action method
        public IActionResult Index()
        {
            ICustomerService customerService = new CustomerService();
            List<Customer> customers = customerService.GetCustomers();
            return View(customers);
        }
    }
}
