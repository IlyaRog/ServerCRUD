using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerCRUD.Core.ApplicationServices;
using ServerCRUD.Core.DomainServices;

namespace ServerCRUD.Infrastructure.Services
{
    public class ConsoleMessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepo;

        public ConsoleMessageService(IMessageRepository messageRepo) => _messageRepo = messageRepo;

        void IMessageService.DeleteMessage(int senderId, int messageId)
        {
            throw new NotImplementedException();
        }

        void IMessageService.MarkAsRead(int recipierId, int messageId)
        {
            throw new NotImplementedException();
        }

        void IMessageService.SendMessage(int senderId, int recipierId, string text)
        {
            throw new NotImplementedException();
        }

        void IMessageService.UpdateMessage(int senderId, int messageId, string newText)
        {
            throw new NotImplementedException();
        }
    }
}
