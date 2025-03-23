using Microsoft.AspNetCore.Mvc;

namespace BasicRazorViewApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
