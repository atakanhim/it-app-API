using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Employe.DeleteEmploye
{
    public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
    {
        public string Id { get; set; }
    }
}
