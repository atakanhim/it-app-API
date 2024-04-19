using itApp.Application.Repositories;
using itApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using itApp.Persistence.Context;
using itApp.Application.Utilities;

namespace itApp.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly itDbContext _context;
        public ReadRepository(itDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();//IQquarylbe oldugundan dolayı

        public IQueryable<T> GetAll(bool tracking = true)
        {

            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public async Task<bool> IsExists(string id)
        {
            if (Guid.TryParse(id, out Guid parsedId))
                return await Table.AnyAsync(p => p.Id == parsedId);

            return false;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {

            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            // return Table.SingleAsync(method);

            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T?> GetByIdAsync(string id, bool tracking = true)// pattern olack
        {
            // return await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id)); // reflection yapmaktansa baseentity yaptık
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(p => p.Id == CustomGuidConverter.Instance.StringToGuidConverter(id));
        }
    }
}
