using Microsoft.AspNetCore.Mvc;

namespace ShoppingPortal.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
