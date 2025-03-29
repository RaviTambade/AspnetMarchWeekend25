using Microsoft.AspNetCore.Mvc;
using ShoppingPortal.Models;

namespace ShoppingPortal.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //step 2: Create an Action Method
        public IActionResult Create()  
        {
            //request processing logic for displaying the form
            Product theProduct = new Product();
            theProduct.Name = "Tata Naxon";
            theProduct.Price = 450000;
            theProduct.Id = 101;
            return View(theProduct);
        }

        //step 3: Create an  POST Action Method
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (TryValidateModel(product))
            {

                //onsuccessfull data entry
                //send to file, databsase using 
                //serialization or database connectivity code

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(product);
            }

            //request processing logic for submitting the form

            //pass this data to service

            //return RedirectToAction("Index");


            //return View();
        }
    }
}
