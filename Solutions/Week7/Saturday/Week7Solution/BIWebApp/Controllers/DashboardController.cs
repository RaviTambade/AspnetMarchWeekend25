using BIWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BIWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public List<TreeNode> Tree { get; set; }


        public DashboardController()
        {
            // Simulated tree
            Tree = new List<TreeNode>
            {
                new TreeNode { Id = 1, Name = "Flowers" },
                new TreeNode { Id = 2, Name = "Fruites" },
                new TreeNode { Id = 2, Name = "Vegetables" }
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Chart loads from JS
        }

        [HttpGet]
        public IActionResult Explore()
        {
            
            return View(Tree);
        }


        // GET: /Dashboard/GetItems    ---> rest API get method 
        // This method returns a list of items based on the nodeId

        public JsonResult GetItems(int nodeId)
        {
            nodeId = 2;
            // Normally, fetch from database
            var allItems = new List<Item>
            {
                new Item { Id = 1, Name = "Gerbera", TreeNodeId = 1 },
                new Item { Id = 2, Name = "Mango", TreeNodeId = 2 },
                new Item { Id = 3, Name = "Rose", TreeNodeId = 1 }
            };

            var items = allItems.Where(i => i.TreeNodeId == nodeId).ToList();
            return new JsonResult(items);
        }
    }
}
