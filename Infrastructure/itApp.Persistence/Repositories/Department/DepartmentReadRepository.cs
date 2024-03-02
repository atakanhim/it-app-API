using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Persistence.Repositories
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        private readonly itDbContext _context;

        public DepartmentReadRepository(itDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsDepartmentNameExists(string departmentName)
        {
            // İsim kontrolü yapılırken büyük-küçük harf duyarlılığına dikkat edin
            return await _context.Departments.AnyAsync(d => d.Name.ToLower() == departmentName.ToLower());
        }
    }
}
