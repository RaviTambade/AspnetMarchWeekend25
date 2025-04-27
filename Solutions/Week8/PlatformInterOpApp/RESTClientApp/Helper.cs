
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientApp
{
    public class Helper
    {
        public static async Task invokeRestAPI()
        {
            //https://jsonplaceholder.typicode.com/posts

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://localhost:5266/api/products/");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
