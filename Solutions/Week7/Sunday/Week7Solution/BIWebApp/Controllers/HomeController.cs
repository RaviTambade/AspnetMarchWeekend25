using System.Diagnostics;
using BIWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace BIWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int workerThreadID=Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread ID: {workerThreadID}");
            return View();
        }

        public IActionResult Privacy()
        {
            int workerThreadID = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread ID: {workerThreadID}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
