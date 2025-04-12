using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tarasenko_lab4.Constants;
using Tarasenko_lab4.Exceptions;
using Tarasenko_lab4.Services;

namespace Tarasenko_lab4.Validators
{
    internal class DataValidator
    {
        public static void ValidateBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Today)
            {
                throw new FutureBirthDateException();
            }
            if (PersonService.GetAge(birthDate) > ApplicationConstants.AGE_THRESHOLD)
            {
                throw new BirthDateOutOfRangeException();
            }
        }

        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException();

            string pattern = @"^[a-zA-Z0-9\.]+@[a-zA-Z0-9]+(?:\.[a-zA-Z]{2,})+$";

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                throw new InvalidEmailException();
            }
        }

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException();
            }
        }

        public static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new InvalidLastNameException();
            }
        }
    }
}
