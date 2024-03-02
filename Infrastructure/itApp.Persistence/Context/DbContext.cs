using itApp.Domain.Entities;
using itApp.Domain.Entities.Common;
using itApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace itApp.Persistence.Context
{
    public class itDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public itDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employe> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employe>()
                  .HasOne(e => e.AppUser)              // Employee sınıfının bir kullanıcısı olmalıdır
                  .WithMany(u => u.Employees)          // Bir kullanıcı birden fazla çalışana sahip olabilir
                  .HasForeignKey(e => e.AppUserId)     // Employee sınıfının AppUserId alanı bir dış anahtar
                  .IsRequired();                        // Bu ilişki zorunlu,

            modelBuilder.Entity<Employe>()
                 .HasOne(e => e.Department)
                 .WithMany(d => d.Employees)
                 .HasForeignKey(e => e.DepartmentId);        
            
            modelBuilder.Entity<LeaveRequest>()
                 .HasOne(e => e.LeaveType)
                 .WithMany(d => d.LeaveRequests)
                 .HasForeignKey(e => e.LeaveTypeId);      
            
            modelBuilder.Entity<LeaveRequest>()
                 .HasOne(e => e.Employee)
                 .WithMany(d => d.LeaveRequests)
                 .HasForeignKey(e => e.EmployeeId);




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker : entity üzerinden yapılan degişiklerin yada yeni eklenen vernin yakalanmasını saglayan property. Track edilen verileri yakalar

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var entity in datas)
            {

                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow

                };


            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
 }

















