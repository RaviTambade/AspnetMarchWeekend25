using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public async  Task<IActionResult> Index()
        {

            //https://jsonplaceholder.typicode.com/posts

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://localhost:8000/flowers/");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }


            return View();
        }
    }
}
