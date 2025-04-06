using Microsoft.AspNetCore.Mvc;
using ShoppingPortal.Models;

namespace ShoppingPortal.Controllers
{
    public class CollectController : Controller
    {
        // GET method: Displays the form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST method: Handles form submission and displays data
        [HttpPost]
        public IActionResult Index(FormData formData)
        {
            if (ModelState.IsValid)
            {
                // Pass the submitted form data to the View
                return View("Result", formData);
            }

            // If the form submission is not valid, return to the form page
            return View(formData);
        }

        // GET method: Displays the result page
        public IActionResult Result(FormData formData)
        {
            return View(formData);
        }
    }
}
