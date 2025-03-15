using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
