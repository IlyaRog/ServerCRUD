using System.Runtime.InteropServices;
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

        Message IMessageRepository.CreateMessage(Message message)
        {
            throw new NotImplementedException();
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
