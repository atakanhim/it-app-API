using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeWithCheckmark
{
    public class GetEmployeeWithCheckMarkQueriesRequest:IRequest<GetEmployeeWithCheckMarkQueriesResponse>
    {
        public string EmployeeId { get; set; }

    }
}
