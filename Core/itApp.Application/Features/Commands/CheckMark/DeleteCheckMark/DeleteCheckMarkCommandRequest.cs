using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.CheckMark.DeleteCheckMark
{
    public class DeleteCheckMarkCommandRequest: IRequest<DeleteCheckMarkCommandResponse>
    {
        public string Id { get; set; }
    }
}
