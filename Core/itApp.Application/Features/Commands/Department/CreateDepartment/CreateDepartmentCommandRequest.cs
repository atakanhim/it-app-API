using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandRequest : IRequest<CreateDepartmentCommandResponse>
    {
        public string Name { get; set; }

    }
}
