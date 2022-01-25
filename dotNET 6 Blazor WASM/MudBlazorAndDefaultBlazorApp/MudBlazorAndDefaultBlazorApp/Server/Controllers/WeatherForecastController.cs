using Microsoft.AspNetCore.Mvc;
using MudBlazorAndDefaultBlazorApp.Shared;

namespace MudBlazorAndDefaultBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(DateTime fromDate, DateTime untilDate)
        {
            // When counting days in a given range (fromDate - untilDate) count whole days (ignore hours and minutes)
            // and include both fromDate and untilDate into range by adding 1.
            int countDays = (untilDate.Date - fromDate.Date).Days + 1;
            return Enumerable.Range(0, countDays).Select(index => new WeatherForecast
            {
                Date = fromDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}