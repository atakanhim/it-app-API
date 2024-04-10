using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs.EmployeeDTOs;

using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeNoInclude
{
    public class GetEmployeeNoIncludeQueriesHandler : IRequestHandler<GetEmployeeNoIncludeQueriesRequest, GetEmployeeNoIncludeQueriesResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly IMapper mapper;

        public GetEmployeeNoIncludeQueriesHandler(IEmployeReadRepository employeReadRepository, IUserService userService, IMapper mapper)
        {
            _employeReadRepository = employeReadRepository;
            _userService = userService;
            this.mapper = mapper;
        }
        public async Task<GetEmployeeNoIncludeQueriesResponse> Handle(GetEmployeeNoIncludeQueriesRequest request, CancellationToken cancellationToken)
        {
          
                try
                {
                    Employe? query = await _employeReadRepository.GetByIdAsync(request.EmployeeId);
                    if (query == null)
                        throw new Exception("Employee bulunamadı");

                EmployeeDTOIncludeNothing _employeDTO = mapper.Map<Employe, EmployeeDTOIncludeNothing>(query);
                    return new()
                    {
                        Employee = _employeDTO,
                    };
                }
                catch (Exception)
                {
                    throw;
                }
          
        }
    }
}
