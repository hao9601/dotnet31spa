using dotnet31spa.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet31spa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly WeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be 0", nameof(id));
            }

            return Ok(await _weatherForecastRepository.Delete(id).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest(new ArgumentException($"'{nameof(id)}' cannot be 0", nameof(id)));
            }

            return Ok(await _weatherForecastRepository.GetById(id).ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<WeatherForecast> result = await _weatherForecastRepository.GetAllAsync().ConfigureAwait(false);

            if (!result?.Any() ?? true)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                return BadRequest(new ArgumentNullException(nameof(weatherForecast)));
            }

            return Ok(await _weatherForecastRepository.Insert(weatherForecast).ConfigureAwait(false));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                return BadRequest(new ArgumentNullException(nameof(weatherForecast)));
            }

            return Ok(await _weatherForecastRepository.Update(weatherForecast).ConfigureAwait(false));
        }
    }
}