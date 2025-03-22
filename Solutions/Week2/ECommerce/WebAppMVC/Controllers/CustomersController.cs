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


            //start using View Technology to decide how data will be sent to the View 
            //ViewBag is a dynamic object that can be used to pass data to the view
            //ViewBag.allCustomers = customers;
            ViewData["myCustomers"] = customers;

            //ViewData is a dictionary object that can be used to pass data to the view


            //TempData is a dictionary object that can be used to pass data to the View
            //as well as the next request

            //TempData["tempCustomers"] = customers;
           //return  RedirectToAction("history", "Customers");

            return View();
            //return View(customers);
        }
    
        public IActionResult History()
        {
            List<Customer> customers = TempData["tempCustomers"] as List<Customer>;
            return View(customers);
        }
    }
}
