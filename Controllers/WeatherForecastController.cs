using Microsoft.AspNetCore.Mvc;

namespace WebApiNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        .ToList();
        }
    }

    [HttpGet]
    [Route("Get/weatherforecast")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando lista de datos del clima");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if(ListWeatherForecast.Count <= index)
        {
            return BadRequest("The given ID is out of bounds");
        }
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
