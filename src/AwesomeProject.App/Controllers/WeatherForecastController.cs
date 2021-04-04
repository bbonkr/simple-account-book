using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using AwesomeProject.App.Models;

using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Filters;
using kr.bbon.AspNetCore.Models;
using kr.bbon.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomeProject.App.Controllers
{
    [ApiVersion(DefaultValues.ApiVersion)]
    [ApiController]
    [Area(DefaultValues.AreaName)]
    [Route(DefaultValues.RouteTemplate)]
    [ApiExceptionHandlerFilter]
    public class WeatherForecastController : ApiControllerBase
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponseModel<IEnumerable<WeatherForecast>>))]
        public IActionResult Get()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return StatusCode(HttpStatusCode.OK, data);
        }

        [ApiVersion("0.9", Deprecated =true)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponseModel<IEnumerable<WeatherForecast>>))]
        public IActionResult GetV0_9()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return StatusCode(HttpStatusCode.OK, data);
        }

        [ApiVersion("0.8", Deprecated = true)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponseModel<IEnumerable<WeatherForecast>>))]
        [ProducesErrorResponseType(typeof(ApiResponseModel<ErrorModel>))]
        public IActionResult GetV0_8()
        {
            throw new SomethingWrongException<ErrorModel>(
                "Test exception",
                new ErrorModel
                {
                    Code = "Some code",
                    Message = "Some message",
                    InnerError = new ErrorModel
                    {
                        Code = "Some inner code",
                        Message = "Some inner message",
                    }
                });
        }
    }
}
