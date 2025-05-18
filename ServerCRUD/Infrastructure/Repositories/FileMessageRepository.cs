using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Core.DomainServices;

namespace ServerCRUD.Infrastructure.Repositories
{
    public class FileMessageRepository : IMessageRepository
    {
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
