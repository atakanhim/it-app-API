using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Abstractions.Utilities
{
    public interface ICustomGuidConverter
    {
        Guid StringToGuidConverter(string str);
        string GuidToStringConverter(Guid guid);
    }
}
