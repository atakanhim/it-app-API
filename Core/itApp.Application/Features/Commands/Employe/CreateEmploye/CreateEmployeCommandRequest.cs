using MediatR;


namespace itApp.Application.Features.Commands.Employe.CreateEmploye
{
    public class CreateEmployeCommandRequest : IRequest<CreateEmployeCommandResponse>
    {
        public string EmployeName { get; set; }
        public string EmployeSurname{ get; set; }
        public int EmployeTelNo { get; set; }
        public int RemainingLeaveDays { get; set; } = 20;
        public string AppUserId { get; set; }
        public string DepartmentId { get; set; }

    }
}
