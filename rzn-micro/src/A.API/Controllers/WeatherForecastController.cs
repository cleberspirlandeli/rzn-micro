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
        public async Task<IActionResult> Post([FromBody] AddUserCommand command)
        {
            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);

            /*
{
    "user": {
        "fullName": "Teste Swagger",
        "dateBirth": "1992-12-18",
        "active": true,
        "gender": 0
    },
        "address": {
        "zipCode": "14412444",
        "street": "Rua teste",
        "number": 123,
        "additionalInformation": "Add info",
        "typeOfAddress": 0
    }
}
             */
        }

        [HttpGet("id:guid")]
        [ProducesResponseType(typeof(AddUserCommandResult), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetUserByIdQuery query)
        {
            var response = await _requestContext.ProcessAsync(query);
            return Ok(response);
        }
    }
}