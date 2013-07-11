using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContracts;
using System.ServiceModel;

namespace Common.Repositories.UserRepository
{
    /// <summary>
    /// Contrat du Repository User
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdAndPassword(string identifier, string password);
    }
}
