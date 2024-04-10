using itApp.Application.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeNoInclude
{
    public class GetEmployeeNoIncludeQueriesResponse
    {
        public EmployeeDTOIncludeNothing Employee { get; set; }

    }
}
