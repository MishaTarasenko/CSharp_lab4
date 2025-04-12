using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tarasenko_lab4.Model;

namespace Tarasenko_lab4.Repositories
{
    internal class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSKMAStorage");

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);
        }

        public async Task AddOrUpdateAsync(DBPerson person)
        {
            string jsonObj = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(GetFilePath(person), false))
            {
                await sw.WriteAsync(jsonObj);
            }
        }

        public async Task<List<DBPerson>> GetAllAsync()
        {
            var res = new List<DBPerson>();

            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                await Task.Delay(2000);
                string jsonObj;
                using (StreamReader sr = new StreamReader(file))
                {
                    jsonObj = await sr.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(jsonObj));
            }

            return res;
        }

        public async Task<bool> DeleteAsync(DBPerson person)
        {
            if (person == null)
                return false;

            string filePath = GetFilePath(person);

            if (!File.Exists(filePath))
                return false;

            try
            {
                await Task.Run(() => File.Delete(filePath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(DBPerson originalPerson, DBPerson updatedData)
        {
            if (originalPerson == null || updatedData == null)
                return false;

            string originalFilePath = GetFilePath(originalPerson);
            string newFilePath = GetFilePath(updatedData);

            if (!File.Exists(originalFilePath))
                return false;

            try
            {
                if (originalFilePath != newFilePath)
                {
                    if (File.Exists(newFilePath))
                    {
                        File.Delete(newFilePath);
                    }

                    File.Move(originalFilePath, newFilePath);
                }

                string jsonObj = JsonSerializer.Serialize(updatedData);
                await File.WriteAllTextAsync(newFilePath, jsonObj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update failed: {ex.Message}");
                return false;
            }
        }

        private string GetFilePath(DBPerson person)
        {
            return Path.Combine(BaseFolder, person.Email);
        }
    }
}
