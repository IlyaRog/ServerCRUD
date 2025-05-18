using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.ApplicationServices
{
    public interface IUserService
    {
        User Register(string login, string password, string phone, int age, string mail);
        User GetUserById(int id);
        User GetUserBylogin(string login);
        void UpdatePassword(int userId, string password);
        void UpdatePhone(int userId, string phone);
        void UpdateEmail(int userId, string email);
        void DeleteUser(int userId);
    }
}
