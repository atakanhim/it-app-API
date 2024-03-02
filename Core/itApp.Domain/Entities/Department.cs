using itApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Employe> Employees { get; set; }
    }
}
