using itApp.Domain.Entities;
using itApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace itApp.Persistence.Context
{
    public class itDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public itDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employe> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employe>()
                  .HasOne(e => e.AppUser)              // Employee sınıfının bir kullanıcısı olmalıdır
                  .WithMany(u => u.Employees)          // Bir kullanıcı birden fazla çalışana sahip olabilir
                  .HasForeignKey(e => e.AppUserId)     // Employee sınıfının AppUserId alanı bir dış anahtar
                  .IsRequired();                        // Bu ilişki zorunlu
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
 }
