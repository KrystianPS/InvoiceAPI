using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
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
        public IEnumerable<WeatherForecast> Get(int scope, int maxTemp, int minTemp)
        {
            var rng = new Random();
            return Enumerable.Range(1, scope).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(minTemp, maxTemp),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int scope, [FromQuery] int maxTemp, [FromQuery] int minTemp)
        {

            if (scope < 0 || maxTemp < minTemp)
            {
                return BadRequest();
            }
            var result = Get(scope, maxTemp, minTemp);
            return Ok(result);
        }


    }
}
