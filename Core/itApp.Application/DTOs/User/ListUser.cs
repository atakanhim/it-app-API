using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs.User
{
    public class ListUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
 
        public IEnumerable<EmployeDTO>? Employees { get; set; }
    }
}

