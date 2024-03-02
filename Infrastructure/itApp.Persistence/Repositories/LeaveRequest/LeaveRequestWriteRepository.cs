using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class LeaveRequestWriteRepository : WriteRepository<LeaveRequest>, ILeaveRequestWriteRepository
    {
        public LeaveRequestWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
