using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Business.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdAndPassword(string identifier, string password);
    }
}
