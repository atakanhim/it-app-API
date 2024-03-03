using itApp.Application.Features.Commands.Department.CreateDepartment;
using MediatR;


namespace itApp.Application.Features.Commands.CheckMark.CreateCheckMark
{
    public class CreateCheckMarkCommandRequest: IRequest<CreateCheckMarkCommandResponse>
    {
        public DateTime Date { get; set; }
        public double WorkingHours { get; set; } = 8;
        public double OvertimeHours { get; set; } = 0;
        public Boolean IsPresent { get; set; } = true;
        public string EmployeeId { get; set; }
    }
}
