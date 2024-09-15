using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("weatherforecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Count)]
                }
            };
        }

        [HttpGet("all")]
        public IActionResult GetAll(int? sortStrategy = null)
        {
          
            if (sortStrategy.HasValue && sortStrategy != 1 && sortStrategy != -1)
            {
                return BadRequest("Некорректное значение параметра sortStrategy.");
            }

           
            var summaries = sortStrategy switch
            {
                null => Summaries,
                1 => Summaries.OrderBy(summary => summary).ToList(),
                -1 => Summaries.OrderByDescending(summary => summary).ToList(),
                _ => throw new ArgumentException("Некорректное значение параметра sortStrategy")
            };

            return Ok(summaries);
        }

        [HttpPost("push")]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            Summaries.Add(name);
            return Ok();
        }

        private bool IsIndexValid(int id, int n)
        {
            return id >= 0 && id < n;
        }

        [HttpGet("GetSummariesID")]
        public IActionResult Get(int ID)
        {
            if (!IsIndexValid(ID, Summaries.Count))
            {
                return BadRequest("Invalid index.");
            }

            return Ok(Summaries[ID]);
        }

        [HttpPut("Update")]
        public IActionResult Update(int ID, string newVal)
        {
            if (!IsIndexValid(ID, Summaries.Count) || string.IsNullOrWhiteSpace(newVal))
            {
                return BadRequest("Invalid index or empty value.");
            }

            Summaries[ID] = newVal;
            return Ok(Summaries);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string name)
        {
            name = name?.Trim();
            if (string.IsNullOrWhiteSpace(name) || !Summaries.Any())
            {
                return BadRequest("Name cannot be empty or list is empty.");
            }

            int count = Summaries.Count(summary => summary == name);
            return Ok(count);
        }
    }
}