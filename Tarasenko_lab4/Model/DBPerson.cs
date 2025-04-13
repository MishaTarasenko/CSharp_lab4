using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Validators;

namespace Tarasenko_lab4.Model
{
    internal class DBPerson
    {
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime BirthDate { get; }

        public DBPerson(string name, string lastName, string email, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
