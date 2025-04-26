using Microsoft.AspNetCore.Mvc;

namespace ExternalDataAccessWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
