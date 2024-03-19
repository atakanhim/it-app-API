using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Employe.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest :  IRequest<UpdateEmployeeCommandResponse>
    {
        public string Id { get; set; }
        public string EmployeName { get; set; }
        public string EmployeSurname { get; set; }
        public string EmployeTelNo { get; set; }
        public string DepartmentId { get; set; }
    }
}
