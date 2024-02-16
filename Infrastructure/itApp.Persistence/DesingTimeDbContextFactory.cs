
using itApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace itApp.Persistence
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<itDbContext>
    {
        itDbContext IDesignTimeDbContextFactory<itDbContext>.CreateDbContext(string[] args)
        {
            //egerki talimat powershell üzerinden geliyorsa ,
            //hangi options parametlerini default olarak kabul etmesi gerektigini belirtiyor.

            DbContextOptionsBuilder<itDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new itDbContext(dbContextOptionsBuilder.Options); // burda dbconteximizde options verdik
        }
    }
}
