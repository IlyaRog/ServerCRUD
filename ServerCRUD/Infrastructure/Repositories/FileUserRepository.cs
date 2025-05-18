using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Core.DomainServices;

namespace ServerCRUD.Infrastructure.Repositories
{
    public class FileUserRepository : IUserRepository
    {
        User IUserRepository.CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetByMail(string mail)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.UpdateDataUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
