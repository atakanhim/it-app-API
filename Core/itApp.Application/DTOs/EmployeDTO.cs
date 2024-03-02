using itApp.Domain.Entities.Identity;
using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs
{
    public class EmployeDTO:BaseDTO
    {
        public string EmployeName { get; set; }
        public string EmployeSurname { get; set; }
        public ICollection<LeaveRequestDTO> LeaveRequests { get; set; }
        public Department Department { get; set; }
    }
}
