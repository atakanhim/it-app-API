using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs.EmployeeDTOs;
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

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeWithCheckmark
{
    public class GetEmployeeWithCheckMarkQueriesHandler : IRequestHandler<GetEmployeeWithCheckMarkQueriesRequest, GetEmployeeWithCheckMarkQueriesResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly IMapper mapper;

        public GetEmployeeWithCheckMarkQueriesHandler(IUserService userService, IEmployeReadRepository employeReadRepository, IMapper mapper)
        {
            _userService = userService;
            _employeReadRepository = employeReadRepository;
            this.mapper = mapper;
        }

        public async Task<GetEmployeeWithCheckMarkQueriesResponse> Handle(GetEmployeeWithCheckMarkQueriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Employe? query = await _employeReadRepository.GetAll()
                                .Include(x => x.CheckMarks)
                                .Include(x => x.Department)
                                .Where(z => z.Id == CustomGuidConverter.Instance.StringToGuidConverter(request.EmployeeId)).FirstOrDefaultAsync();
                if (query == null)
                    throw new Exception("Employee bulunamadı");

                EmployeeDTOIncludeCheckMark _employeDTO = mapper.Map<Employe, EmployeeDTOIncludeCheckMark>(query);
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
