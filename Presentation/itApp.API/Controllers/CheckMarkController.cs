using itApp.Application.Features.Commands.CheckMark.CreateCheckMark;
using itApp.Application.Features.Commands.Department.CreateDepartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckMarkController : ControllerBase
    {
        readonly IMediator _mediator;

        public CheckMarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCheckMarkCommandRequest request)
        {
            CreateCheckMarkCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
