using System.Diagnostics;
using FromPuneWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FromPuneWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Console.WriteLine("HomeController constructor called");
            _logger = logger;
        }

        public IActionResult Index()
        {
            Console.WriteLine("Index action method called");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
