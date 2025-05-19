using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text.Json;
using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Core.DomainServices;

namespace ServerCRUD.Infrastructure.Repositories
{
    public class FileMessageRepository : IMessageRepository
    {
        private readonly string _msgPath;
        public FileMessageRepository(string path)
        {
            if (Directory.Exists(path))
                Console.WriteLine("Folder found");
            else
            {
                Console.WriteLine("Folder not found");
                Directory.CreateDirectory(path);
            }
            _msgPath = path;
        }

        public Message CreateMessage(int senderId, int recipientId, string text)
        {
            var files = Directory.GetFiles(_msgPath, "*.json");

            var ids = files.Select(file =>
            {
                var name = Path.GetFileNameWithoutExtension(file);
                return int.TryParse(name, out int id) ? id : -1;
            }
            ).Where(id => id >= 0);

            int newId = ids.Any() ? ids.Max() + 1 : 1;
            Message newMessage = new(newId, MessageStatus.IsSent, text, senderId, recipientId);

            string json = JsonSerializer.Serialize(newMessage, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(_msgPath, $"{newMessage.Id}.json");
            File.WriteAllText(filePath, json);

            return newMessage;
        }

        public void DeleteMessage(int id)
        {
            var filePath = Path.Combine(_msgPath, $"{id}.json");
            if (!Directory.Exists(filePath)) File.Delete(filePath);
            else Console.WriteLine("File not found");
        }

        public List<Message> GetAllMessages(int senderId, int recipierId)
        {
            List<Message> messages = new List<Message>();

            var files = Directory.GetFiles(_msgPath, "*.json");
            foreach (string file in files)
            {
                var json = File.ReadAllText(file);
                try
                {
                    var message = JsonSerializer.Deserialize<Message>(json);

                    if (message.SenderId == senderId && message.RecipientId == recipierId)
                    {
                        messages.Add(message);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
            return messages.OrderBy(m => m.DateSend).ToList();
        }

        public Message GetById(int id)
        {
            string json;

            var filePath = Path.Combine(_msgPath, $"{id}.json");
            if (!Directory.Exists(filePath)) json = File.ReadAllText(filePath);
            else throw new Exception("Message not found");
            
            Message message = JsonSerializer.Deserialize<Message>(json) ?? throw new Exception("Error. You cannot deserialize null to a message.");

            return message;
        }

        public Message UpdateMessage(int id, Action<Message> updateAction)
        {
            var files = Directory.GetFiles(_msgPath, "*.json");

            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var message = JsonSerializer.Deserialize<Message>(json);

                if (message != null && message.Id == id)
                {
                    updateAction(message);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string updatedJson = JsonSerializer.Serialize(message, options);
                    File.WriteAllText(file, updatedJson);

                    return message;
                }
            }
            throw new Exception($"Message with ID:{id} is not found");
        }
    }
}
