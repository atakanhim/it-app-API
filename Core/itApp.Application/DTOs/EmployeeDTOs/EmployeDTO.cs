using itApp.Domain.Entities.Identity;
using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itApp.Application.DTOs.FromChekMarkToEmployee;

namespace itApp.Application.DTOs.EmployeeDTOs
{
    public class EmployeeDTOIncludeNothing : BaseEmployeeDTO
    {
    }
    public class EmployeDTOIncludeAll : BaseEmployeeDTO
    {
        public ICollection<LeaveRequestDTO> LeaveRequests { get; set; }
        public ICollection<CheckMarkDTO> CheckMarks { get; set; }
    }
    public class EmployeeDTOIncludeCheckMark : BaseEmployeeDTO
    {
        public ICollection<CheckMarkDTO> CheckMarks { get; set; }
    }
    public class EmployeeDTOIncludeLeaveRequest : BaseEmployeeDTO
    {
        public ICollection<LeaveRequestDTO> LeaveRequests { get; set; }
    }
   
}
