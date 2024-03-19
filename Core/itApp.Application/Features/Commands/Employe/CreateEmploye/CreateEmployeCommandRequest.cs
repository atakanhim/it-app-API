using MediatR;


namespace itApp.Application.Features.Commands.Employe.CreateEmploye
{
    public class CreateEmployeCommandRequest : IRequest<CreateEmployeCommandResponse>
    {
        public string EmployeName { get; set; }
        public string EmployeSurname{ get; set; }
        public string EmployeTelNo { get; set; }
        public string AppUserId { get; set; }
        public string DepartmentId { get; set; }

    }
}
