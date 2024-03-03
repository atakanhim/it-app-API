﻿using itApp.Application.Features.Commands.AppUser.RefreshTokenLogin;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees;
using itApp.Application.Features.Queries.EmployeeQueries.GetEmployee;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace itApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeCommandRequest request)
        {
            CreateEmployeCommandResponse response = await _mediator.Send(request);
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
    }
}
