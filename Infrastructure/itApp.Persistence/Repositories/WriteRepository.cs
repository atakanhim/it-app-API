﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itApp.Persistence.Context;
using itApp.Application.Repositories;
using itApp.Domain.Entities.Common;

namespace itApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly itDbContext _context;
        public WriteRepository(itDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityentry = await Table.AddAsync(entity);

            return entityentry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entitys)
        {
            Table.RemoveRange(entitys);
            return true;
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            T? Model = await Table.FirstOrDefaultAsync(p => p.Id == id);
            
            return Remove(Model!);
        }


        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State != EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


        // unit of work
    }
}
