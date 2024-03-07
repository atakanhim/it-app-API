using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace itApp.Persistence.Repositories
{
    public class EmployeReadRepository : ReadRepository<Employe>, IEmployeReadRepository
    {
        private readonly itDbContext _context;
        public EmployeReadRepository(itDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsEmployeExists(string telNo)
        {
            // İsim kontrolü yapılırken büyük-küçük harf duyarlılığına dikkat edin
            return await _context.Employees.AnyAsync(d => d.EmployeTelNo == telNo);
        }
    }
}
