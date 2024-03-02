using itApp.Domain.Entities;


namespace itApp.Application.Repositories
{
    public interface ILeaveRequestReadRepository: IReadRepository<LeaveRequest>
    {
        public Task<bool> IsLeaveRequestExists(string reason);
    }
}
