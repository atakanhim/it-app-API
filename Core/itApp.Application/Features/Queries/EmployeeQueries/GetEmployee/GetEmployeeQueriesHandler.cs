using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs.EmployeeDTOs;
using itApp.Application.Exceptions;
using itApp.Application.Features.Commands.CheckMark.CreateCheckMark;
using itApp.Application.Repositories;
using itApp.Application.Utilities;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployee
{
    public class GetEmployeeQueriesHandler : IRequestHandler<GetEmployeeQueriesRequest, GetEmployeeQueriesResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly IMapper mapper;

        public GetEmployeeQueriesHandler(IEmployeReadRepository employeReadRepository, IUserService userService, IMapper mapper)
        {
            _employeReadRepository = employeReadRepository;
            _userService = userService;
            this.mapper = mapper;
        }


        public async Task<GetEmployeeQueriesResponse> Handle(GetEmployeeQueriesRequest request, CancellationToken cancellationToken)
        {
           
                try
                {
                    Employe? query = await _employeReadRepository.GetAll()
                             .Include(x => x.CheckMarks)
                             .Include(x => x.Department)
                             .Include(d => d.LeaveRequests)
                                 .ThenInclude(dt => dt.LeaveType).Where(z => z.Id == CustomGuidConverter.Instance.StringToGuidConverter(request.EmployeeId)).FirstOrDefaultAsync();
                    if (query == null)
                        throw new Exception("Employee bulunamadı");

                EmployeDTOIncludeAll _employeDTO = mapper.Map<Employe, EmployeDTOIncludeAll>(query);
                    return new()
                    {
                        Employee = _employeDTO,
                    };
                }
                catch (Exception ex)
                {
                    throw;
                }
            
            
        }
    }
}
