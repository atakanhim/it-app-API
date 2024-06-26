﻿using itApp.Application.Features.Commands.AppUser.RefreshTokenLogin;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Features.Commands.Employe.DeleteEmploye;
using itApp.Application.Features.Commands.Employe.UpdateEmployee;
using itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees;
using itApp.Application.Features.Queries.EmployeeQueries.GetEmployee;
using itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeWithCheckmark;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeCommandRequest request)
        {
            CreateEmployeCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommandRequest request)
        {
            UpdateEmployeeCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeCommandRequest request)
        {
            //DeleteEmployeeCommandRequest request = new DeleteEmployeeCommandRequest() { Id=id};
            DeleteEmployeeCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEmployeesForUser([FromQuery] GetAllEmployeesForUserQueriesRequest request)
        {
            GetAllEmployeesForUserQueriesResponse response = await _mediator.Send(request);
            return Ok(response);
        } 
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployee([FromQuery] GetEmployeeQueriesRequest request)
        {
            GetEmployeeQueriesResponse response = await _mediator.Send(request);
            return Ok(response);
        }  
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeeWithCheckMark([FromQuery] GetEmployeeWithCheckMarkQueriesRequest request)
        {
            GetEmployeeWithCheckMarkQueriesResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
