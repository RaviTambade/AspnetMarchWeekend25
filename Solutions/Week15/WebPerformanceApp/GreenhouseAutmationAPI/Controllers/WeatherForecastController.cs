using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GreenhouseAutmationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        public WeatherForecastController(IMemoryCache cache)
        {
            _cache = cache;

        }

        [HttpGet]
        public IActionResult Get()
        {    
            // Check if the weather data is cached
            if ( !_cache.TryGetValue("WeatherData", out string weather))
            {
                // If not cached, simulate fetching weather data
                // In a real application, you would fetch this from a weather service
                weather = "Sunny, 25°C " + DateTime.Now;
                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30)); // Cache for 30 seconds
                // Save data in cache
                _cache.Set("WeatherData", weather, cacheEntryOptions);
            }
                return Ok(weather);
            }
        }
    }

        // First  requets , runs logic, caches the result
        //Next requests within 30 seconds, return cached result instantly
