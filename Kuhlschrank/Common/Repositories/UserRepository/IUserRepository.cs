using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContracts;
using System.ServiceModel;

namespace Common.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdAndPassword(string identifier, string password);
    }
}
