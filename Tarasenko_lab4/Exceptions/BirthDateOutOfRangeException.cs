using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    class BirthDateOutOfRangeException : Exception
    {
        public BirthDateOutOfRangeException()
          : base("Error: The date of birth is too far in the past. We only deal with living people.") { }

        public BirthDateOutOfRangeException(string message)
            : base(message) { }
    }
}
