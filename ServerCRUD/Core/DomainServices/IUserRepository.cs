using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.DomainServices
{
    public interface IUserRepository
    {
        User CreateUser(string login, string password, string phone, int age, string mail);
        User GetById(int id);
        User GetByLogin(string login);
        User UpdateDataUser(int id, Action<User> updateAction);
        void DeleteById(int id);
    }
}
