using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs.EmployeeDTOs
{
    public class BaseEmployeeDTO : BaseDTO
    {
        public string AppUserId { get; set; }
        public string EmployeName { get; set; }
        public string EmployeSurname { get; set; }
        public string EmployeTelNo { get; set; }
        public int UsedLeaveDays { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
