using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.LeaveType.CreateLeaveType
{
    public class CreateLeaveTypeCommandRequest : IRequest<CreateLeaveTypeCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfDaysAllowed { get; set; }
    }
}
