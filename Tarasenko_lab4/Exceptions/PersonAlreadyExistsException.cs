using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Exceptions
{
    class PersonAlreadyExistsException : Exception
    {
        public PersonAlreadyExistsException()
            : base("Error: Person with this email already exists.") { }

        public PersonAlreadyExistsException(string message)
            : base(message) { }
    }
}
