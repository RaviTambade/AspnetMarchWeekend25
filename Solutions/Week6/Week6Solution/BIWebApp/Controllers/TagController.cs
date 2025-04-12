using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
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

    }
}
