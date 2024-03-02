using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.LeaveRequest.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandRequest : IRequest<CreateLeaveRequestCommandResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public string LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }

    }
}
