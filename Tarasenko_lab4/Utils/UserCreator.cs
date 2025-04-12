using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Model;

namespace Tarasenko_lab4.Utils
{
    internal class UserCreator
    {
        public static List<DBPerson> GetPersons()
        {
            List<DBPerson> list = new List<DBPerson>
            {
                new DBPerson("William", "Johnson", "william.johnson@outlook.com", new DateTime(1981, 1, 15)),
                new DBPerson("Sophia", "Williams", "sophia.williams@outlook.com", new DateTime(1996, 3, 22)),
                new DBPerson("Benjamin", "Jones", "benjamin.jones@outlook.com", new DateTime(1984, 10, 8)),
                new DBPerson("Charlotte", "Brown", "charlotte.brown@outlook.com", new DateTime(1980, 7, 19)),
                new DBPerson("Samuel", "Davis", "samuel.davis@outlook.com", new DateTime(1991, 5, 4)),
                new DBPerson("Amelia", "Miller", "amelia.miller@outlook.com", new DateTime(1974, 9, 27)),
                new DBPerson("Joseph", "Wilson", "joseph.wilson@outlook.com", new DateTime(1999, 11, 13)),
                new DBPerson("Evelyn", "Moore", "evelyn.moore@outlook.com", new DateTime(1988, 2, 28)),
                new DBPerson("Henry", "Taylor", "henry.taylor@outlook.com", new DateTime(2001, 4, 7)),
                new DBPerson("Abigail", "Anderson", "abigail.anderson@outlook.com", new DateTime(1971, 6, 24)),
                new DBPerson("Christopher", "Thomas", "christopher.thomas@outlook.com", new DateTime(1994, 8, 14)),
                new DBPerson("Harper", "Jackson", "harper.jackson@outlook.com", new DateTime(1983, 12, 11)),
                new DBPerson("Daniel", "White", "daniel.white@outlook.com", new DateTime(1978, 11, 20)),
                new DBPerson("Emily", "Harris", "emily.harris@outlook.com", new DateTime(1993, 7, 9)),
                new DBPerson("Matthew", "Martin", "matthew.martin@outlook.com", new DateTime(1977, 5, 2)),
                new DBPerson("Elizabeth", "Thompson", "elizabeth.thompson@outlook.com", new DateTime(1985, 10, 31)),
                new DBPerson("Andrew", "Garcia", "andrew.garcia@outlook.com", new DateTime(1998, 4, 23)),
                new DBPerson("Avery", "Martinez", "avery.martinez@outlook.com", new DateTime(1987, 1, 17)),
                new DBPerson("David", "Robinson", "david.robinson@outlook.com", new DateTime(1975, 8, 16)),
                new DBPerson("Sofia", "Clark", "sofia.clark@outlook.com", new DateTime(1995, 3, 5)),
                new DBPerson("Jackson", "Rodriguez", "jackson.rodriguez@outlook.com", new DateTime(1979, 2, 1)),
                new DBPerson("Scarlett", "Lewis", "scarlett.lewis@outlook.com", new DateTime(1982, 11, 26)),
                new DBPerson("Sebastian", "Lee", "sebastian.lee@outlook.com", new DateTime(1997, 9, 15)),
                new DBPerson("Victoria", "Walker", "victoria.walker@outlook.com", new DateTime(1972, 5, 10)),
                new DBPerson("Carter", "Hall", "carter.hall@outlook.com", new DateTime(1989, 3, 22)),
                new DBPerson("Madelyn", "Allen", "madelyn.allen@outlook.com", new DateTime(2000, 12, 18)),
                new DBPerson("Wyatt", "Young", "wyatt.young@outlook.com", new DateTime(1973, 9, 14)),
                new DBPerson("Lillian", "Hernandez", "lillian.hernandez@outlook.com", new DateTime(1992, 8, 7)),
                new DBPerson("Julian", "King", "julian.king@outlook.com", new DateTime(1974, 7, 4)),
                new DBPerson("Addison", "Wright", "addison.wright@outlook.com", new DateTime(1986, 6, 29)),
                new DBPerson("Ryan", "Lopez", "ryan.lopez@outlook.com", new DateTime(1996, 4, 19)),
                new DBPerson("Natalie", "Hill", "natalie.hill@outlook.com", new DateTime(1981, 12, 12)),
                new DBPerson("Nathan", "Scott", "nathan.scott@outlook.com", new DateTime(1976, 11, 5)),
                new DBPerson("Brooklyn", "Green", "brooklyn.green@outlook.com", new DateTime(1991, 10, 31)),
                new DBPerson("Caleb", "Adams", "caleb.adams@outlook.com", new DateTime(1978, 9, 25)),
                new DBPerson("Zoey", "Baker", "zoey.baker@outlook.com", new DateTime(1987, 8, 18)),
                new DBPerson("Christian", "Gonzalez", "christian.gonzalez@outlook.com", new DateTime(1999, 7, 13)),
                new DBPerson("Audrey", "Nelson", "audrey.nelson@outlook.com", new DateTime(1979, 6, 8)),
                new DBPerson("Landon", "Carter", "landon.carter@outlook.com", new DateTime(1984, 5, 3)),
                new DBPerson("Claire", "Mitchell", "claire.mitchell@outlook.com", new DateTime(1994, 4, 28)),
                new DBPerson("Jonathan", "Perez", "jonathan.perez@outlook.com", new DateTime(1977, 3, 23)),
                new DBPerson("Savannah", "Roberts", "savannah.roberts@outlook.com", new DateTime(1983, 2, 17)),
                new DBPerson("Isaiah", "Turner", "isaiah.turner@outlook.com", new DateTime(1990, 1, 11)),
                new DBPerson("Allison", "Phillips", "allison.phillips@outlook.com", new DateTime(1975, 12, 6)),
                new DBPerson("Eli", "Campbell", "eli.campbell@outlook.com", new DateTime(1988, 11, 30)),
                new DBPerson("Anna", "Parker", "anna.parker@outlook.com", new DateTime(1993, 10, 25)),
                new DBPerson("Connor", "Evans", "connor.evans@outlook.com", new DateTime(1974, 9, 20)),
                new DBPerson("Stella", "Edwards", "stella.edwards@outlook.com", new DateTime(1985, 8, 15)),
                new DBPerson("Hudson", "Collins", "hudson.collins@outlook.com", new DateTime(1997, 7, 10)),
                new DBPerson("Paisley", "Stewart", "paisley.stewart@outlook.com", new DateTime(1972, 6, 5))
            };
            return list;
        }
    }
}
