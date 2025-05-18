namespace ServerCRUD.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public Role Role { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string? PhoneNumber { get; private set; }
        public int Age { get; private set; }
        public string Mail { get; private set; }

        public User(int id, Role role, string login, string password, string phone, int age, string mail) 
        {
            if (!Enum.IsDefined(typeof(Role), role)) throw new ArgumentException("Invalid role value");
            
            if(string.IsNullOrWhiteSpace(login)) throw new ArgumentException("Login is required");
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required");
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Phone is reqired");
            if(string.IsNullOrWhiteSpace(mail)) throw new ArgumentException("Mail is required");
            if(age < 18) throw new ArgumentException("Age is not correct");

            Id = id;
            Role = role;
            Login = login;
            Password = password; 
            PhoneNumber = phone; 
            Age = age; 
            Mail = mail;
        }
        public void UpdatePassword(string newPassword) { Password = newPassword; }
        public void UpdatePhoneNumber(string newPhoneNumber) { PhoneNumber = newPhoneNumber; }
    }
}
