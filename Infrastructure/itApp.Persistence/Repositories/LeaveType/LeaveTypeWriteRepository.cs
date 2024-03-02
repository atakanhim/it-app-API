using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class LeaveTypeWriteRepository : WriteRepository<LeaveType>, ILeaveTypeWriteRepository
    {
        public LeaveTypeWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
