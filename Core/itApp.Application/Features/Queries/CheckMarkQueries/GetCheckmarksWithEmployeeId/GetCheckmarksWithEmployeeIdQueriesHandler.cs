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
                    int n1 = request.Month;
                    DateTime start = new DateTime(DateTime.Now.Year, n1, 1);
                    DateTime finish;

                    if (n1 == 12)                     
                        finish = new DateTime(DateTime.Now.Year + 1, 1, 1);
                    else
                        finish = new DateTime(DateTime.Now.Year, n1 + 1, 1);
                    

                    IEnumerable<CheckMark> checkMarks = await _readRepository.GetAll()
                        .Include(x => x.Employee)
                            .ThenInclude(dt => dt.Department)
                        .Where(x => x.EmployeeId == result && x.Date >= start && x.Date < finish)
                        .OrderBy(x => x.Date) // Tarihe göre sıralama
                        .ToListAsync();

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
