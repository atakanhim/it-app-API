using itApp.Application.DTOs.EmployeeDTOs;
using itApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs.FromChekMarkToEmployee
{
    public class CheckMarkDTO : BaseCheckMarkDTO
    {
 
    }
    public class CheckMarkDTOIncludeEmployee : BaseCheckMarkDTO
    {
        public EmployeeDTOIncludeNothing Employee { get; set; }

    }
}
