using Azure.Core;
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
        public async Task LeaveRequestControl(string reason , DateTime start,DateTime end, Guid employeeId)
        {
            if (start >= end)         
                throw new ArgumentException("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
            

            bool leaveReason = await _context.LeaveRequests.AnyAsync(d => d.Reason == reason && d.EmployeeId == employeeId);
            if (leaveReason)
                throw new Exception("Aynı izin sebebiyle bir izin olusturulmus.");

            bool leaveRequestExists = await _context.LeaveRequests
                  .AnyAsync(lr => lr.EmployeeId == employeeId &&
                                  (
                                      (start >= lr.StartDate && start <= lr.EndDate) ||
                                      (end >= lr.StartDate && end <= lr.EndDate) ||
                                      (start <= lr.StartDate && end >= lr.EndDate)
                                  )
                              );

            if(leaveRequestExists)            
                throw new Exception("Bu Tarihler arasında izin zaten alınmis.");

        }
    }
}
