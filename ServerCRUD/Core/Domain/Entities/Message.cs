namespace ServerCRUD.Core.Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public User Sender { get; private set; }
        public User Recipient { get; private set; }
        public MessageStatus Status { get; private set; }
        public DateTime DateSend { get; private set; }
        public DateTime? DateUpdate { get; private set; }
        public DateTime? DateDelete { get; private set; }
        public string Text { get; private set; }

        public Message(int id, User sender, User recipient, MessageStatus status, string text)
        {
            if(String.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text is not correct");

            Id = id;
            Sender = sender;
            Recipient = recipient;
            Status = status;
            DateSend = DateTime.Now;
            Text = text;
        }
        
        private void RefreshDateUpdate() => DateUpdate = DateTime.Now;
        private void RefreshDateDelete() => DateDelete = DateTime.Now;
        private void RefreshStatus(MessageStatus status) => Status = status;

        
        public void MarkAsSendError() => RefreshStatus(MessageStatus.SendingError);
        public void MarkAsSend() => RefreshStatus(MessageStatus.IsSent);
        public void MarkAsRead() => RefreshStatus(MessageStatus.IsRead);

    }
}