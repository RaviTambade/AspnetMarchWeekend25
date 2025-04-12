using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



















        public IActionResult SalesStats()
        {
            var stats = new { TotalSales = 1000, Revenue = 50000 };
            return PartialView("SalesStats", stats);
        }

        public IActionResult RecentOrders()
        {
            var orders = new[] {
                new { OrderId = 1, Product = "Phone", Price = 300 },
                new { OrderId = 2, Product = "Laptop", Price = 800 }
            };
            return PartialView("RecentOrders", orders);
        }

        public IActionResult CustomerActivity()
        {
            var activities = new[] {
                "User1 logged in", "User2 placed an order", "User3 left a review"
            };
            return PartialView("CustomerActivity", activities);
        }
    }
}

