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

        public Message(int id, User sender, User recipient, MessageStatus status, DateTime DateSend, string Text)
        {
            //Дописать конструктор, методы обновления статуса и свойств DateTime
        }
    }
}