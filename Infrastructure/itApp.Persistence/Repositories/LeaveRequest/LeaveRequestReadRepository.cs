using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace itApp.Persistence.Repositories
{
    public class LeaveRequestReadRepository : ReadRepository<LeaveRequest>, ILeaveRequestReadRepository
    {
        private readonly itDbContext _context;
        public LeaveRequestReadRepository(itDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsLeaveRequestExists(string reason)
        {
            // İsim kontrolü yapılırken büyük-küçük harf duyarlılığına dikkat edin
            return await _context.LeaveRequests.AnyAsync(d => d.Reason == reason);
        }
    }
}
