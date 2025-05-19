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

        Message IMessageRepository.DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        List<Message> IMessageRepository.GetAllMessages(int senderId, int recipierId)
        {
            throw new NotImplementedException();
        }

        Message IMessageRepository.GetById(User sender, int id)
        {
            throw new NotImplementedException();
        }

        Message IMessageRepository.UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
