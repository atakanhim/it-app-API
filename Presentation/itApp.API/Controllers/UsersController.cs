using MediatR;
using Microsoft.AspNetCore.Mvc;
using itApp.Application.Features.Commands.AppUser.CreateUser;
using Microsoft.AspNetCore.Authorization;
using itApp.Application.Features.Queries.AppUser.GetAllUsers;
using itApp.Application.Features.Queries.AppUser.GetUser;
using itApp.Domain.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        } 

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQueryRequest getAllUsersQueryRequest)
        {

            GetAllUserQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }     
       // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQueryRequest getUserQueryRequest)
        {
                GetUserQueryResponse response = await _mediator.Send(getUserQueryRequest);
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                // Nesneleri JSON'a dönüştür
                string json = JsonConvert.SerializeObject(response.User, settings);

                return Ok(json);
        
        }
    }
}
