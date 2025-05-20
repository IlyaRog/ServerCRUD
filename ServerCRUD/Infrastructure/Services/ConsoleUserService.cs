using System.Reflection.Metadata.Ecma335;
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
            _userRepo.DeleteById(userId);
        }
        User IUserService.GetUserById(int id)
        {
            return _userRepo.GetById(id);
        }
        User IUserService.GetUserBylogin(string login)
        {
            return _userRepo.GetByLogin(login);
        }
        User IUserService.Register(string nickname, string login, string password, string phone, DateTime birthDay, string mail)
        {
            return _userRepo.CreateUser(nickname, login, password, phone, birthDay, mail);
        }
        void IUserService.UpdateEmail(int userId, string mail)
        {
            _userRepo.UpdateDataUser(userId, f => f.UpdateMail(mail));
        }
        void IUserService.UpdatePassword(int userId, string password)
        {
            _userRepo.UpdateDataUser(userId,f => f.UpdatePassword(password));
        }
        void IUserService.UpdatePhone(int userId, string phone)
        {
            _userRepo.UpdateDataUser(userId, f => f.UpdatePhoneNumber(phone));
        }
    }
}
