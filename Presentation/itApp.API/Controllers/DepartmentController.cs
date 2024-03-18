using itApp.Application.Features.Commands.Department.CreateDepartment;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentCommandRequest request)
        {
            CreateDepartmentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll( [FromQuery] GetAllDepartmentsQueriesRequest request)
        {
            GetAllDepartmentsQueriesResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
