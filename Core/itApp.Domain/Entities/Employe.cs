using itApp.Domain.Entities.Common;
using itApp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Domain.Entities
{
    public class Employe:BaseEntity
    {
        public string EmployeName { get; set; }
        public string EmployeSurname{ get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
