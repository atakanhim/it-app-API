using itApp.Domain.Entities;
using itApp.Persistence.Context;


namespace itApp.Persistence.Repositories
{
    public class CheckMarkWriteRepository : WriteRepository<CheckMark>
    {
        public CheckMarkWriteRepository(itDbContext context) : base(context)
        {
        }
    }
}
