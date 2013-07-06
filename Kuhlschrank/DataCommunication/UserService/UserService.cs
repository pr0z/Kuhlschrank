using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using Common.Helpers;
using DataContracts;
using Common.Repositories.UserRepository;
using DataAccess.UserRepositoriesImplementation;

namespace DataCommunication.UserService
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo = new UserSqlServerRepository();

        public User GetUserFromIdAndPassword(string identifier, string password)
        {
            return _userRepo.GetUserFromIdAndPassword(identifier, password);
        }

        public User GetById(int id)
        {
            return _userRepo.GetById(id);
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public void Insert(User user)
        {
            _userRepo.Insert(user);
        }

        public void Update(User entity)
        {
            _userRepo.Update(entity);
        }

        public void Update(int id, string nom, string prenom, string mail)
        {
            User user = _userRepo.GetAll().Where(o => o.ID == id).FirstOrDefault();
            if (user != null)
            {
                user.Nom = nom;
                user.Prenom = prenom;
                user.Mail = mail;

                Update(user);
            }
        }

        public void Delete(User user)
        {
            _userRepo.Delete(user);
        }
    }
}
