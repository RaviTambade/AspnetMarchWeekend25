using BIWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Chart loads from JS
        }

        [HttpGet]
        public IActionResult GetChartData()
        {
            var data = new ChartDataViewModel
            {
                Labels = new List<string> { "10:00", "10:05", "10:10", "10:15" },
                Values = new List<int> { 120, 150, 170, 200 }
            };

            return Json(data);
        }
    }
}
