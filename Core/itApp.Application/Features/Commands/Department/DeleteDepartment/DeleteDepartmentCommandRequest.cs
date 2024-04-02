using itApp.Application.Features.Commands.Employe.DeleteEmploye;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandRequest: IRequest<DeleteDepartmentCommandResponse>
    {
        public string Id { get; set; }
    }
}
