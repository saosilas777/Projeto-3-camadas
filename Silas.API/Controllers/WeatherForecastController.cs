using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silas.API.Controllers
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
        private readonly IPerson _person;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPerson person)
        {
            _logger = logger;
            _person = person;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("Create")]

        public async Task<object> Create([FromBody] PersonDTO person)
        {
            var result = _person.Create(person);
            return await Task.FromResult(result);
        }

        public async Task<object> GetPerson(string id)
        {
            var get = _person.Get(Guid.Parse(id));
            return await Task.FromResult(get);
        }
    }
}
