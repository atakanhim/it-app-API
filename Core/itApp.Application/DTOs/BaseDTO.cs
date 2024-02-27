using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; } // belki kullanmak istemeyiz diye ezilebilir yapıyoruz
    }
}
