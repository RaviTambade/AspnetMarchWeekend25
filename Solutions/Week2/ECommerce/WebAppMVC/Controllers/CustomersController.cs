using Microsoft.AspNetCore.Mvc;
using CRMLib.Services.Interfaces;
using CRMLib.Entities;

namespace WebAppMVC.Controllers
{
    //MVC Controller
    public class CustomersController : Controller
    {

        ICustomerService _svc;

        //Constructor  Dependency Injection
        public CustomersController(ICustomerService svc)
        {
            _svc = svc;
        }
        //action method
        public IActionResult Index()
        {
            //Consuming the services through the interface
            List<Customer> customers = _svc.GetCustomers();
            return View(customers);
        }
    }
}
