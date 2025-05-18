using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD.Core.DomainServices
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User GetById(int id);
        User GetByLogin(string login);
        User GetByPhone(string phone);
        User GetByMail(string mail);
        User UpdateDataUser(User user);
        void DeleteById(int id);
    }
}
