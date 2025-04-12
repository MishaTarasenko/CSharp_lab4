using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Error: Invalid email adress.") { }

        public InvalidEmailException(string message)
            : base(message) { }
    }
}
