using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs;
using itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees;
using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments
{
    public class GetAllDepartmentsQueriesHandler : IRequestHandler<GetAllDepartmentsQueriesRequest, GetAllDepartmentsQueriesResponse>
    {
        private readonly IDepartmentReadRepository   _departmentReadRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueriesHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository)
        {
            _mapper = mapper;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetAllDepartmentsQueriesResponse> Handle(GetAllDepartmentsQueriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Department>? query =  await _departmentReadRepository.GetAll().ToListAsync();
                if (query == null)
                    throw new Exception("Hiç departman bulunamadı");
                IEnumerable<DepartmentDTO> dto = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(query);

                return new ()
                {
                    Departments = dto
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
