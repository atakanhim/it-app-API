using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Persistence.Repositories
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
