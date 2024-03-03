using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Exceptions
{
    public class IdParseErrorException : Exception
    {
        public IdParseErrorException() : base("String To Guid Parse Error")
        {
        }

        public IdParseErrorException(string? message) : base(message)
        {
        }
    }
 
}
