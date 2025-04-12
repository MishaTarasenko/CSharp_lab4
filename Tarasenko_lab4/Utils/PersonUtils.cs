using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarasenko_lab4.Utils
{
    internal class PersonUtils
    {
        public static bool IsAdult(DateTime birthDate)
        {
            return GetAge(birthDate) >= 18;
        }

        public static bool IsTodayBirthday(DateTime birthDate)
        {
            return birthDate.Day == DateTime.Today.Day && birthDate.Month == DateTime.Today.Month;
        }

        public static int GetAge(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;
            if (date.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
