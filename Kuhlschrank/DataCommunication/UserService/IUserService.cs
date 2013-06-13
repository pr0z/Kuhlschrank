using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataContracts;


namespace DataCommunication.UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(int id, string nom);
    }
}
