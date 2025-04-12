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
            int[] data1 = { 407, 876, 8755, 7000, 8900, 1500 };
            ViewData["data1"] = data1;

            int[] data2 = { 407, 6000, 8755, 9000, 8900, 987 };
            ViewData["data2"] = data2;
            return View();
        }

        public IActionResult Comp()
        {
            return View();
        }
    }
}
