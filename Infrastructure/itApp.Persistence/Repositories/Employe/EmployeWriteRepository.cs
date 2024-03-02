using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class EmployeWriteRepository : WriteRepository<Employe>, IEmployeWriteRepository
    {
        public EmployeWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
