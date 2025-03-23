using Microsoft.AspNetCore.Mvc;

namespace BasicRazorViewApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
