using System.Globalization;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace ServerCRUD.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; }
        public Role Role { get; private set; }
        public string Nickname { get; set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string Mail { get; private set; }

        [JsonConstructor]
        private User(int id, Role role, string nickname, string login, string password, string phoneNumber, DateTime birthDay, string mail)
        {

            Id = id;
            Role = role;
            Nickname = nickname;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay;
            Mail = mail;
        }
        private static bool IsAdult(DateTime birthDay)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDay.Year;

            return age >= 18;
        }
        public static User Create(int id, Role role,string nickname, string login, string password, string phoneNumber, DateTime birthDay, string mail)
        {
            if (!Enum.IsDefined(typeof(Role), role)) throw new ArgumentException("Invalid role value");
            if (string.IsNullOrWhiteSpace(login)) throw new ArgumentException("Login is required");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required");
            if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("Phone is reqired");
            if (string.IsNullOrWhiteSpace(mail)) throw new ArgumentException("Mail is required");
            if (!mail.Contains('@')) throw new ArgumentException("Invalid email format");
            if (!IsAdult(birthDay)) throw new ArgumentException("Age is not correct");

            return new User(id, role, nickname, login, password, phoneNumber, birthDay, mail);
        }
        public void UpdatePassword(string newPassword) => Password = newPassword;
        public void UpdatePhoneNumber(string newPhoneNumber) => PhoneNumber = newPhoneNumber;
        public void UpdateBirthDay(DateTime newDate) {
            if (IsAdult(newDate)) BirthDay = newDate; 
            else throw new Exception("Age is not correct"); 
        }
        public void UpdateNickname(string newNickname) => Nickname = newNickname;
        public void UpdateMail(string newMail) {
            if (string.IsNullOrWhiteSpace(newMail)) throw new ArgumentException("Mail is required");
            if (!newMail.Contains('@')) throw new ArgumentException("Invalid email format");

            Mail = newMail;
        }
        public override string ToString()
        {
            return $"Id:{Id} Login:{Login}";
        }
    }
}
