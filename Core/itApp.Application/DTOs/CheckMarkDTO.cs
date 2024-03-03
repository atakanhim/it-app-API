using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs
{
    public class CheckMarkDTO
    {
        public DateTime Date { get; set; }
        public double WorkingHours { get; set; } = 8;
        public double OvertimeHours { get; set; } = 0;
        public Boolean IsPresent { get; set; } = true;
        public Guid EmployeeId { get; set; }
        //public Employe Employee { get; set; }
    }
}
