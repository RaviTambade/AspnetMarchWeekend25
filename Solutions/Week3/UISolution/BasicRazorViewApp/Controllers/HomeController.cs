using System.Diagnostics;
using BasicRazorViewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicRazorViewApp.Controllers
{

    //Two Types of Controllers in asp.net core
    //1. MVC Controller
    //has a view 
    //View generates response with HTML, CSS, JS, Razor Syntax , Bootstrap UI

    //2. API Controller
    //does not have a view
    // generates response in JSON,
    // XML, CSV, PDF, Excel,
    // Image, Video, Audio, Text
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        //action methods
        

        public IActionResult Index()
        {
            //Request processing
            // CALL BUSINESS lOGIC
            // CALL Service Logic
            // CALL DATA ACCESS LOGIC
            //Response generation
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

        //attribute ,  metadata, Decorator

        [HttpGet]
        public IActionResult Contactus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactus(string name, string email, string contactnumber)
        {

            Console.WriteLine(name + " " + email + "  " + contactnumber);

            return View();
        }


        public IActionResult Services()
        {
            return View();
        }


    }
}
