using itApp.Application.Features.Commands.CheckMark.CreateCheckMark;
using itApp.Application.Features.Commands.CheckMark.DeleteCheckMark;
using itApp.Application.Features.Commands.Department.CreateDepartment;
using itApp.Application.Features.Commands.Employe.DeleteEmploye;
using itApp.Application.Features.Queries.CheckMarkQueries.GetCheckmarksWithEmployeeId;
using itApp.Application.Features.Queries.EmployeeQueries.GetEmployee;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
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
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCheckMarkCommandRequest request)
        {
            //DeleteEmployeeCommandRequest request = new DeleteEmployeeCommandRequest() { Id=id};
            DeleteCheckMarkCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCheckmarksWithEmployeeId([FromQuery] GetCheckmarksWithEmployeeIdQueriesRequest request)
        {
            GetCheckmarksWithEmployeeIdQueriesResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
