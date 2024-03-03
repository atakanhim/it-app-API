using itApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class CheckMark:BaseEntity
    {
        public DateTime Date { get; set; } 
        public double WorkingHours { get; set; } = 8;
        public double OvertimeHours { get; set; } = 0;
        public Boolean IsPresent { get; set; } = true;

        public Guid EmployeeId { get; set; }
        public Employe Employee { get; set; }
    }
}
