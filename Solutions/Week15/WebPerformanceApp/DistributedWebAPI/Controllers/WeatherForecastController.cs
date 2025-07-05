using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
         
        private readonly IDistributedCache _distCache;
        public WeatherForecastController(IDistributedCache cache)
        {

            _distCache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Check if the weather data is cached
            var weather = await _distCache.GetStringAsync("WeatherData");
            if (string.IsNullOrEmpty(weather))
            {
                // If not cached, simulate fetching weather data
                // In a real application, you would fetch this from a weather service
                weather = "Sunny, 25°C " + DateTime.Now;
                // Set cache options
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30)); // Cache for 30 seconds
                // Save data in cache
                await _distCache.SetStringAsync("WeatherData", weather, options);
            }
            return Ok(weather);


        }
    }
}
