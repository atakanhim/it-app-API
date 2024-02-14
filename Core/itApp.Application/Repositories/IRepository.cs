using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Repositories
{
    public interface IRepository <T> where T : class
    {
      //  DbSet<T> Table { get; }// nedne get dedik DbSet sadece get yaparız zaten dbcontext set ettik
    }
}
