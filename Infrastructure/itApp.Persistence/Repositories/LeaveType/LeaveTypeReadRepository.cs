using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace itApp.Persistence.Repositories
{
    public class LeaveTypeReadRepository : ReadRepository<LeaveType>, ILeaveTypeReadRepository
    {
        private readonly itDbContext _context;
        public LeaveTypeReadRepository(itDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsLeaveTypeExists(string name)
        {
            // İsim kontrolü yapılırken büyük-küçük harf duyarlılığına dikkat edin
            return await _context.LeaveTypes.AnyAsync(d => d.Name == name);
        }
    }
}
