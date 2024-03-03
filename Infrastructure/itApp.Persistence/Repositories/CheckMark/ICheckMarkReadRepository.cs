using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class CheckMarkReadRepository : ReadRepository<CheckMark>
    {
        public CheckMarkReadRepository(itDbContext context) : base(context)
        {
        }
    }
}
