using ServerCRUD.Core.ApplicationServices;
using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Core.DomainServices;

namespace ServerCRUD.Infrastructure.Services
{
    public class ConsoleUserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public ConsoleUserService(IUserRepository userRepo) => _userRepo = userRepo;

        void IUserService.DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
        User IUserService.GetUserById(int id)
        {
            throw new NotImplementedException();
        }
        User IUserService.GetUserBylogin(string login)
        {
            throw new NotImplementedException();
        }
        User IUserService.Register(string login, string password, string phone, int age, string mail)
        {
            throw new NotImplementedException();
        }
        void IUserService.UpdateEmail(int userId, string email)
        {
            throw new NotImplementedException();
        }
        void IUserService.UpdatePassword(int userId, string password)
        {
            throw new NotImplementedException();
        }
        void IUserService.UpdatePhone(int userId, string phone)
        {
            throw new NotImplementedException();
        }
    }
}
