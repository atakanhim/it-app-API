using itApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class LeaveType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
         //  public int NumberOfDaysAllowed { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
