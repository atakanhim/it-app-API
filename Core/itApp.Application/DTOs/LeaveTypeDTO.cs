using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs
{
    public class LeaveTypeDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
      //  public int NumberOfDaysAllowed { get; set; }

    }
}
