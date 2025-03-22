using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingPortal.Models;

namespace ShoppingPortal.Controllers
{
    public class HomeController : Controller
    {
        
        //action methods

        public IActionResult Index()
        {
            //request processing logic
            string  message= "Products Available for sale";
            ViewBag.theMessage = message;

            //Annonymous Type
            //Property Initiazer
            //Auto Property

            ViewBag.thePerson = new
            {
                FirstName = "Sachin",
                LastName = "Patil",
                Age = 23
            };




            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aboutus()
        {

            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }


        //output:   prestable output using HTML, CSS, JAVSCRIPT
        public IActionResult Services()
        {
            return View();
        }



        //Web API

        //output: JSON objet as Content
        public IActionResult Address()
        {
            var companyAddress = new
            {
                Name = "Transflower",
                Location = "Pune Satara Road",
                City = "Pune",
                State = "Maharashtra"
            };
            return Json(companyAddress);
        }
    }
}
