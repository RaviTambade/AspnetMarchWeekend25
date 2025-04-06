using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewOnlyWebApp.Repositories;
using ViewOnlyWebApp.Services;

namespace ViewOnlyWebApp.Pages.Catalog
{
    public class ListModel : PageModel
    {
        public void OnGet()
        {
            // This method is called on GET requests to the page.
            // You can add any initialization logic here if needed.

            IProductRepository productRepository = new ProductRepository();

            IProductService productService = new ProductService(productRepository);

            ViewData["flowers"] = productService.GetAllProducts();
        }
    }
}
