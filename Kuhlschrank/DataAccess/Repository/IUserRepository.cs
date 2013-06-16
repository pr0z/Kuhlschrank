using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataAccess.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdAndPassword(string identifier, string password);
    }
}
