using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    class FutureBirthDateException : Exception
    {
        public FutureBirthDateException()
           : base("Error: The date of birth cannot be in the future.") { }

        public FutureBirthDateException(string message)
            : base(message) { }
    }
}
