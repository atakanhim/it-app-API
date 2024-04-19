using itApp.Application.DTOs.EmployeeDTOs;
using itApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees
{
    public class GetAllEmployeesForUserQueriesResponse
    {
        public IEnumerable<EmployeDTOIncludeAll> Employees { get; set; } // Kullanıcı listesi

    }
}
