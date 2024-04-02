using AutoMapper;
using itApp.Application.DTOs;
using itApp.Application.DTOs.FromChekMarkToEmployee;
using itApp.Application.Exceptions;
using itApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments;
using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace itApp.Application.Features.Queries.CheckMarkQueries.GetCheckmarksWithEmployeeId
{
    public class GetCheckmarksWithEmployeeIdQueriesHandler : IRequestHandler<GetCheckmarksWithEmployeeIdQueriesRequest, GetCheckmarksWithEmployeeIdQueriesResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICheckMarkReadRepository _readRepository;
        public GetCheckmarksWithEmployeeIdQueriesHandler(IMapper mapper, ICheckMarkReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task<GetCheckmarksWithEmployeeIdQueriesResponse> Handle(GetCheckmarksWithEmployeeIdQueriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (Guid.TryParse(request.EmployeeId, out Guid result))
                {

                    IEnumerable<CheckMark> checkMarks = await _readRepository.GetAll()
                                  .Include(x => x.Employee)
                                      .ThenInclude(dt => dt.Department).Where(x => x.EmployeeId == result).ToListAsync();

                    IEnumerable<CheckMarkDTOIncludeEmployee> resultModel = _mapper.Map<IEnumerable<CheckMark>, IEnumerable<CheckMarkDTOIncludeEmployee>>(checkMarks);
                    return new() { CheckMarks = resultModel };
                }

                else
                    throw new IdParseErrorException();
            }
            catch(Exception ex)
            {
                throw ;
            }
          
        }
    }
}
