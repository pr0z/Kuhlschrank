using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataCommunication.UserService
{
    public class UserService : IUserService
    {
        public User GetUser(int id, string nom)
        {
            return new User { ID = id, Nom = nom };
        }
    }
}
