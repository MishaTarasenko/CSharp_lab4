using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tarasenko_lab4.Model;
using Tarasenko_lab4.Services;
using Tarasenko_lab4.Utils;

namespace Tarasenko_lab4.Repositories
{
    internal class FileRepository
    {
        //private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PersonStorage");
        private static readonly string BaseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonStorage");
        private bool _isInitialized = false;

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                Task.Run(() => InitializeAsync());
            }
        }

        public async Task InitializeAsync()
        {
            var persons = UserCreator.GetPersons();

            List<Task> tasks = [];
            foreach (var person in persons)
            {
                _ = tasks.Append(AddOrUpdateAsync(person));
            }

            foreach (var task in tasks)
            {
                await task;
            }
        }

        public async Task AddOrUpdateAsync(DBPerson person)
        {
            await Task.Delay(500);
            string jsonObj = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(GetFilePath(person), false))
            {
                await sw.WriteAsync(jsonObj);
            }
        }

        public async Task<DBPerson> GetAsync(string email)
        {
            string filePath = GetFilePath(email);
            if (!File.Exists(filePath))
                return null;
            string jsonObj;
            using (StreamReader sr = new StreamReader(filePath))
            {
                jsonObj = await sr.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBPerson>(jsonObj);
        }

        public async Task<List<DBPerson>> GetAllAsync()
        {
            var res = new List<DBPerson>();

            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                await Task.Delay(50);
                string jsonObj;
                using (StreamReader sr = new StreamReader(file))
                {
                    jsonObj = await sr.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(jsonObj));
            }

            return res;
        }

        public async Task<bool> DeleteAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string filePath = GetFilePath(email);

            if (!File.Exists(filePath))
                return false;

            try
            {
                await Task.Delay(500);
                await Task.Run(() => File.Delete(filePath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetFilePath(DBPerson person)
        {
            return Path.Combine(BaseFolder, person.Email);
        }

        private string GetFilePath(string email)
        {
            return Path.Combine(BaseFolder, email);
        }
    }
}
