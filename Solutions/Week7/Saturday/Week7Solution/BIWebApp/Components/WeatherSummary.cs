
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

namespace BIWebApp.Components
{ 

    public class WeatherSummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string city)
        {
            // Simulate data retrieval
            var forecast = $"Sunny in {city}, 25°C";
            return View("Default", forecast);
        }
    }

}
