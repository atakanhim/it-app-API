using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itApp.Application.DTOs.EmployeeDTOs;

namespace itApp.Application.DTOs.User
{
    public class ListUserWithEmployee
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public IEnumerable<EmployeDTOIncludeAll>? Employees { get; set; }
    }
}
