using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {

            int workerThreadID = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread ID: {workerThreadID}");

            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Danger()
        {
            return View();
        }

        public IActionResult Warn()
        {
            return View();
        }

    }
}
