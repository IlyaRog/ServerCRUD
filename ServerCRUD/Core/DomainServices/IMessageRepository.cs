using System.Dynamic;
using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.DomainServices
{
    public interface IMessageRepository
    {
        Message CreateMessage(Message message);
        Message GetById(User sender, int id);
        List<Message> GetAllMessages(int senderId, int recipierId);
        Message UpdateMessage(Message message);
        Message DeleteMessage(int id);
    }
}
