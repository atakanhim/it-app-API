using itApp.Application.Features.Commands.Department.CreateDepartment;
using itApp.Application.Features.Commands.LeaveRequest.CreateLeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLeaveRequestCommandRequest request)
        {
            CreateLeaveRequestCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
