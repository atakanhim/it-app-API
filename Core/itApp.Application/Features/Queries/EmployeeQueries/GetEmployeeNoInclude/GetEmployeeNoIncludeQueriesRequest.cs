using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployeeNoInclude
{
    public class GetEmployeeNoIncludeQueriesRequest:IRequest<GetEmployeeNoIncludeQueriesResponse>
    {
        public string EmployeeId { get; set; }

    }
}
