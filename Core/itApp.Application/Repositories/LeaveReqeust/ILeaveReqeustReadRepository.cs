using itApp.Domain.Entities;


namespace itApp.Application.Repositories
{
    public interface ILeaveRequestReadRepository: IReadRepository<LeaveRequest>
    {
        Task LeaveRequestControl(string reason, DateTime start, DateTime end, Guid employeeId);
    }
}
