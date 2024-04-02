using itApp.Application.DTOs;
using itApp.Application.DTOs.FromChekMarkToEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Queries.CheckMarkQueries.GetCheckmarksWithEmployeeId
{
    public class GetCheckmarksWithEmployeeIdQueriesResponse
    {
        public IEnumerable<CheckMarkDTOIncludeEmployee>? CheckMarks { get; set; } // Kullanıcı listesi

    }
}
