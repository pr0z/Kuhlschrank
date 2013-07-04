using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContracts;
using DataAccess.WebServices;
using Common.Repositories;
using Common.Repositories.UserRepository;

namespace DataAccess.UserRepositoriesImplementation
{
    public class UserServiceRepository : IUserRepository
    {
        #region IUserRepository Membres

        User IUserRepository.GetUserFromIdAndPassword(string identifier, string password)
        {
            return MyWebServices.UserService.GetUserFromIdAndPassword(identifier, password);
        }

        #endregion

        #region IRepository<User> Membres

        User IRepository<User>.GetById(int id)
        {
            return MyWebServices.UserService.GetUserById(id);
        }

        List<User> IRepository<User>.GetAll()
        {
            return MyWebServices.UserService.GetAll();
        }

        void IRepository<User>.Insert(User entity)
        {
            MyWebServices.UserService.Insert(entity);
        }

        void IRepository<User>.Update(User entity)
        {
            MyWebServices.UserService.Update(entity);
        }

        void IRepository<User>.Delete(User entity)
        {
            MyWebServices.UserService.Delete(entity);
        }

        #endregion
    }
}
