using itApp.Domain.Entities;


namespace itApp.Application.Repositories
{
    public interface ILeaveTypeReadRepository: IReadRepository<LeaveType>
    {
        public Task<bool> IsLeaveTypeExists(string name);
    }
}
