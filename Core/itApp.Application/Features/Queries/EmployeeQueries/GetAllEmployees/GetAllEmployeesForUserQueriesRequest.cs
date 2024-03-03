using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetAllEmployees
{
    public class GetAllEmployeesForUserQueriesRequest:IRequest<GetAllEmployeesForUserQueriesResponse>
    {
        public string UserId { get; set; }

    }
}
