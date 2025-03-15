using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
