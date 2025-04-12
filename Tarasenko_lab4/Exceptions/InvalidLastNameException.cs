using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    class InvalidLastNameException : Exception
    {
        public InvalidLastNameException()
            : base("Error: The last name cannot be empty or whitespace.") { }

        public InvalidLastNameException(string message)
            : base(message) { }
    }
}
