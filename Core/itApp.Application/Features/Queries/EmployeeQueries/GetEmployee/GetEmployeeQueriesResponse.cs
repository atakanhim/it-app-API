using itApp.Application.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployee
{
    public class GetEmployeeQueriesResponse
    {
        public EmployeDTOIncludeAll Employee { get; set; }      
    }
}
