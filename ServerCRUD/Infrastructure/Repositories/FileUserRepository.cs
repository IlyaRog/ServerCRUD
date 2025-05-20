using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Core.DomainServices;
using ServerCRUD.Infrastructure.Settings;

namespace ServerCRUD.Infrastructure.Repositories
{
    public class FileUserRepository : IUserRepository
    {
        private readonly string _usersPath;
        public FileUserRepository(string path) 
        {
            if (Directory.Exists(path))
                Console.WriteLine("Folder found");
            else
            {
                Console.WriteLine("Folder not found");
                Directory.CreateDirectory(path);
            }
            
            _usersPath = path;
        }

        public User CreateUser(string nickname, string login, string password, string phone, DateTime birthDay, string mail)
        {
            var files = Directory.GetFiles(_usersPath, "*.json");

            var ids = files.Select(file =>
            {
                var name = Path.GetFileNameWithoutExtension(file);
                return int.TryParse(name, out int id) ? id : -1;
            }
            ).Where(id => id >= 0);

            int newId = ids.Any() ? ids.Max() + 1 : 1;

            User newUser = User.Create(newId, Role.Default, nickname, login, password, phone, birthDay, mail);

            string json = JsonSerializer.Serialize(newUser, new JsonSerializerOptions{WriteIndented = true});
            string filePath = Path.Combine(_usersPath, $"{newUser.Id}.json");
            File.WriteAllText(filePath, json);

            return newUser;
        }

        public void DeleteById(int id)
        {
            var filePath = Path.Combine(_usersPath, $"{id}.json");
            if (!Directory.Exists(filePath)) File.Delete(filePath);
            else Console.WriteLine("File not found");
        }

        public User GetById(int id)
        {
            string json;

            var filePath = Path.Combine(_usersPath, $"{id}.json");
            if (!Directory.Exists(filePath)) json = File.ReadAllText(filePath);
            else throw new Exception("User not found"); ;

            User user = JsonSerializer.Deserialize<User>(json) ?? throw new Exception("Error. You cannot deserialize null to a user.");
            return user;
        }
        public User GetByLogin(string login)
        {
            var files = Directory.GetFiles(_usersPath, "*.json");

            foreach (var file in files) 
            {
                string json = File.ReadAllText(file);
                try
                {
                    var user = JsonSerializer.Deserialize<User>(json);
                    if (user != null && user.Login == login) return user;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
            throw new Exception($"Error, user.login:{login} not found");
        }
        public User UpdateDataUser(int id, Action<User> updateAction)
        {
            var files = Directory.GetFiles(_usersPath, "*.json");

            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var user = JsonSerializer.Deserialize<User>(json);

                if(user != null && user.Id == id)
                {
                    updateAction(user);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string updatedJson = JsonSerializer.Serialize(user, options);
                    File.WriteAllText(file, updatedJson);
                    
                    return user;
                }
            }
            throw new Exception($"User with ID:{id} is not found");
        }
    }
}
