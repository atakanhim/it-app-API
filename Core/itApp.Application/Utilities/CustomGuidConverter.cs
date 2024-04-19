using itApp.Application.Abstractions.Utilities;
using itApp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Utilities
{
    public class CustomGuidConverter : ICustomGuidConverter
    {
        private static CustomGuidConverter instance;
        public CustomGuidConverter() { }
        public static CustomGuidConverter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomGuidConverter();
                }
                return instance;
            }
        }

        public string GuidToStringConverter(Guid guid) => guid.ToString();
    

        public Guid StringToGuidConverter(string str)
        {
            if (Guid.TryParse(str, out Guid parsedId))
                return parsedId;
            else
                throw new IdParseErrorException();
        }
    }
}
