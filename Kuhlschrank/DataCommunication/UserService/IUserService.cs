using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataContracts;

namespace DataCommunication.UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "fromIAndP?i={identifier}&p={password}")]
        User GetUserFromIdAndPassword(string identifier, string password);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        User GetUserById(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<User> GetAll();

        [OperationContract]
        void Insert(User user);

        [OperationContract]
        void Update(User user);

        [OperationContract]
        void Delete(User user);
    }
}
