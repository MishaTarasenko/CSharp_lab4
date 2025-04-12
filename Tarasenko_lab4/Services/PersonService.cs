using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Model;

namespace Tarasenko_lab4.Services
{
    internal class PersonService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<List<Person>> GetAllUsers()
        {
            var res = new List<Person>();

            foreach (var dbUser in await Repository.GetAllAsync())
            {
                res.Add(new Person(dbUser.Guid, dbUser.Login, dbUser.FirstName, dbUser.LastName));
            }
            return res;
        }

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
