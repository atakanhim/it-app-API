using itApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.CheckMarkQueries.GetCheckmarksWithEmployeeId
{
    public class GetCheckmarksWithEmployeeIdQueriesRequest : IRequest<GetCheckmarksWithEmployeeIdQueriesResponse>
    {
        public string EmployeeId { get; set; }
        public int Month { get; set; } = 0;
        public GetCheckmarksWithEmployeeIdQueriesRequest()
        {
            // Eğer Month değeri boşsa, bulunduğumuz ayın numarasını ata
            if (Month == 0)
            {
                Month = DateTime.Now.Month;
            }
        }

    }
}
