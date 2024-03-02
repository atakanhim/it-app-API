using itApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class LeaveRequest:BaseEntity
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
   
        public string Reason { get; set; }
        public bool IsApproved { get; set; } = true;

        public Guid LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public Guid EmployeeId { get; set; }
        public Employe Employee { get; set; }
    }
}
