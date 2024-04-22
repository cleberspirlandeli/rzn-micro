using Microsoft.AspNetCore.Mvc;
using RznMicro.Atlanta.Contract.Feature.User;
using RznMicro.Atlanta.Core.RequestContext;
using System.Net;

namespace A.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRequestContext _requestContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRequestContext requestContext)
        {
            _logger = logger;
            _requestContext = requestContext;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(AddUserCommandResult), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromBody] AddUserCommand command)
        {
            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);
        }
    }
}