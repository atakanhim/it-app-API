using itApp.Application.Features.Commands.Department.CreateDepartment;
using itApp.Application.Features.Commands.LeaveType.CreateLeaveType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLeaveTypeCommandRequest request)
        {
            CreateLeaveTypeCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
