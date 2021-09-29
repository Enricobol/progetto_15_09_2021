using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.Exceptions
{
    public class SchoolDataException : Exception
    {
        public SchoolDataException(string message, Exception original) : base(message, original)
        {

        }
    }
}
