using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class CheckMarkWriteRepository : WriteRepository<CheckMark>, ICheckMarkWriteRepository
    {
        public CheckMarkWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
