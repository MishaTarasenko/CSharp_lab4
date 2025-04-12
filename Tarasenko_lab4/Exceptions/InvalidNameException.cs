using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    class InvalidNameException : Exception
    {
        public InvalidNameException()
            : base("Error: The name cannot be empty or whitespace.") { }

        public InvalidNameException(string message)
            : base(message) { }
    }
}
