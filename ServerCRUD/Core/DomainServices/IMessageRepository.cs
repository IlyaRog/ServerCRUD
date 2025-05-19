using System.Dynamic;
using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.DomainServices
{
    public interface IMessageRepository
    {
        Message CreateMessage(int sender, int recipient, string text);
        Message GetById(int id);
        List<Message> GetAllMessages(int senderId, int recipierId);
        Message UpdateMessage(int id, Action<Message> updateAction);
        void DeleteMessage(int id);
    }
}
