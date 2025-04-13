using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Exceptions;
using Tarasenko_lab4.Model;
using Tarasenko_lab4.Repositories;

namespace Tarasenko_lab4.Services
{
    internal class PersonService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<List<Person>> GetAllUsersAsync()
        {
            var dbPersons = await Repository.GetAllAsync();
            return dbPersons.Select(p => new Person(p.Name, p.LastName, p.Email, p.BirthDate)).ToList();
        }

        public async Task<bool> AddPerson(Person person)
        {
            DBPerson dBPerson = await Repository.GetAsync(person.Email);
            if (dBPerson != null)
            {
                throw new PersonAlreadyExistsException();
            }
            var dbPerson = new DBPerson(person.Name, person.LastName, person.Email, person.BirthDate);
            await Repository.AddOrUpdateAsync(dbPerson);
            return true;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            DBPerson dBPerson = await Repository.GetAsync(person.Email);
            if (dBPerson != null)
            {
                var dbPerson = new DBPerson(person.Name, person.LastName, person.Email, person.BirthDate);
                await Repository.AddOrUpdateAsync(dbPerson);
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePersonAsync(string email)
        {
            await Repository.DeleteAsync(email);
            return true;
        }
    }
}
