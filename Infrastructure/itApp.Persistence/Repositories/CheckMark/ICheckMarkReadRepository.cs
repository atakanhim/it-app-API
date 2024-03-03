using itApp.Application.Repositories;
using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class CheckMarkReadRepository : ReadRepository<CheckMark>, ICheckMarkReadRepository
    {
        public CheckMarkReadRepository(itDbContext context) : base(context)
        {
        }
    }
}
