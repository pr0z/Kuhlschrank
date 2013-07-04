using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repositories;
using Common.Repositories.UserRepository;
using DataContracts;

namespace DataAccess.UserRepositoriesImplementation
{
    public class UserListRepository : IUserRepository
    {
        private static List<User> _source;

        public UserListRepository()
        {
            if (_source == null)
            {
                _source = new List<User>();
                Insert(new User
                {
                    ID = 0,
                    Mail = "test",
                    Nom = "test",
                    Prenom = "test",
                    Password = "test"
                });
            }
        }

        #region IUserRepository Membres

        public User GetUserFromIdAndPassword(string identifier, string password)
        {
            return _source.Where(o => o.Mail == identifier && o.Password == password).FirstOrDefault();
        }

        #endregion

        #region IRepository<User> Membres

        public User GetById(int id)
        {
            return _source.Where(o => o.ID == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _source;
        }

        public void Insert(User entity)
        {
            _source.Add(entity);
        }

        public void Update(User entity)
        {
            User item = _source.FirstOrDefault(o => o.ID == entity.ID);
            if (item != null)
            {
                item.Mail = entity.Mail;
                item.Nom = entity.Nom;
                item.Password = entity.Password;
                item.Prenom = entity.Prenom;
            }
        }

        public void Delete(User entity)
        {
            User item = _source.FirstOrDefault(o => o.ID == entity.ID);
            if (item != null)
            {
                _source.Remove(item);
            }
        }

        #endregion
    }
}
