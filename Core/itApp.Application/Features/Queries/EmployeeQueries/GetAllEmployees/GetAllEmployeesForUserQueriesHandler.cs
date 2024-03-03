using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs;
using itApp.Application.Exceptions;
using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees
{
    public class GetAllEmployeesForUserQueriesHandler : IRequestHandler<GetAllEmployeesForUserQueriesRequest, GetAllEmployeesForUserQueriesResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly IMapper mapper;

        public GetAllEmployeesForUserQueriesHandler(IEmployeReadRepository employeReadRepository, IUserService userService, IMapper mapper)
        {
            _employeReadRepository = employeReadRepository;
            _userService = userService;
            this.mapper = mapper;
        }

        public async Task<GetAllEmployeesForUserQueriesResponse> Handle(GetAllEmployeesForUserQueriesRequest request, CancellationToken cancellationToken)
        {
          
                try
                {
                var query = await _employeReadRepository.Table
                                .Include(x => x.CheckMarks)
                                .Include(x => x.Department)
                                .Include(d => d.LeaveRequests)
                                    .ThenInclude(dt => dt.LeaveType).Where(z=>z.AppUserId == request.UserId).ToListAsync();


                  ICollection<EmployeDTO> dtoemploye = mapper.Map<ICollection<Employe>, ICollection<EmployeDTO>>(query);




                     return new GetAllEmployeesForUserQueriesResponse()
                     {
                        Employees = dtoemploye
                     };

                }
                catch (Exception ex)
                {
                    throw;
                }
          
        }
    }
}
