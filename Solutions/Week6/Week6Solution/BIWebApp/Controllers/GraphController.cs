using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bar()
        {
            //get data from database
            //get from services---repository pattern---database (JSON, SQL, etc)
            int[] data = { 1200, 75000, 50000, 25000, 300, 15 };
            ViewData["data"] = data;
            return View();
        }

        public IActionResult Comp()
        {
            return View();
        }
    }
}
