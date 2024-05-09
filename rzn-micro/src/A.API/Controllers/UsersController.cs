using Microsoft.AspNetCore.Mvc;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Query;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;
using System.Net;

namespace A.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IRequestContext _requestContext;

        public UsersController(ILogger<UsersController> logger, IRequestContext requestContext)
        {
            _logger = logger;
            _requestContext = requestContext;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(AddUserCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)] // TODO: Create ErrorResponse class
        public async Task<IActionResult> Post([FromBody] AddUserCommand command)
        {
            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);
        }

        [HttpPut("{idUser:guid}/{idAddress:guid}")]
        [ProducesResponseType(typeof(UpdateUserCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid idUser, [FromRoute] Guid idAddress, [FromBody] UpdateUserCommand command)
        {
            command.User.SetId(idUser);
            command.Address.SetId(idAddress);

            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);
        }

        [HttpDelete("{idUser:guid}")]
        [ProducesResponseType(typeof(DeleteUserCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid idUser, [FromRoute] DeleteUserCommand command)
        {
            command.SetId(idUser);
            
            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);
        }

        [HttpGet("id:guid")]
        [ProducesResponseType(typeof(GetUserQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetUserByIdQuery query)
        {
            var response = await _requestContext.QueryAsync(query);
            return Ok(response);
        }        
        
        [HttpGet("")]
        [ProducesResponseType(typeof(GetUserByFilterQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetUserByFilterQuery query)
        {
            var response = await _requestContext.QueryAsync(query);
            return Ok(response);
        }

        [HttpPost("image/upload")]
        [ProducesResponseType(typeof(ImageUploadCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadCommand command)
        {
            var response = await _requestContext.ProcessAsync(command);
            return Ok(response);
        }
    }
}

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