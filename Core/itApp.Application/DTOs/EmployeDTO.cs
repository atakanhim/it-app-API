using itApp.Domain.Entities.Identity;
using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs
{
    public class EmployeDTO : BaseDTO
    {
        public string AppUserId { get; set; }
        public string EmployeName { get; set; }
        public string EmployeSurname { get; set; }
        public string EmployeTelNo { get; set; }
        public int UsedLeaveDays { get; set; }
        public ICollection<LeaveRequestDTO> LeaveRequests { get; set; }
        public ICollection<CheckMarkDTO> CheckMarks { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
