using itApp.Domain.Entities.Common;
using itApp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class Employe:BaseEntity
    {
        public string EmployeName { get; set; }
        public string EmployeSurname{ get; set; }
        public int EmployeTelNo { get; set; }
        public int UsedLeaveDays { get; set; } = 0;

        public ICollection<LeaveRequest> LeaveRequests { get; set; }


        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
