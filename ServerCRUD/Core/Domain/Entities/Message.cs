using System.Text.Json.Serialization;

namespace ServerCRUD.Core.Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public int SenderId { get; private set; }
        public int RecipientId { get; private set; }
        public MessageStatus Status { get; private set; }
        public DateTime DateSend { get; private set; }
        public DateTime? DateUpdate { get; private set; }
        public DateTime? DateDelete { get; private set; }
        public string Text { get; private set; }
        public Message(int id, MessageStatus status, string text) 
        {
            if(String.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text is not correct");
        
            Id = id; 
            Status = status; 
            Text = text; 
        }
        [JsonConstructor]
        public Message(int id, MessageStatus status, string text, int senderId, int recipientId):this(id, status, text) 
        {
            SenderId = senderId;
            RecipientId = recipientId;
            DateSend = DateTime.Now;
            DateUpdate = null;
            DateDelete = null;
        }
        private void RefreshDateUpdate() => DateUpdate = DateTime.Now;
        private void RefreshDateDelete() => DateDelete = DateTime.Now;
        private void RefreshStatus(MessageStatus status) => Status = status;

        
        public void MarkAsSendError() => RefreshStatus(MessageStatus.SendingError);
        public void MarkAsSend() => RefreshStatus(MessageStatus.IsSent);
        public void MarkAsRead() => RefreshStatus(MessageStatus.IsRead);
        public void TextUpdate(string text) => Text = text;
        public override string ToString()
        {
            return $"\nStatus:{Status}\nДата отправки: {DateSend}\nОт кого: {SenderId}\nДля кого: {RecipientId}\n\"{Text}\"\n";
        }
    }
}