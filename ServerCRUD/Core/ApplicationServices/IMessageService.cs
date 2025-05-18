using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.ApplicationServices
{
    public interface IMessageService
    {
        void SendMessage(int senderId, int recipierId, string text);
        void UpdateMessage(int senderId, int messageId, string newText);
        void DeleteMessage(int senderId, int messageId);
        void MarkAsRead(int recipierId, int messageId);
    }
}
