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
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "getbyid?id={id}")]
        User GetUserById(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<User> GetAll();

        [OperationContract]
        void Insert(User user);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "updateUser?id={id}&n={nom}&f={prenom}&m={mail}")]
        void Update(int id, string nom, string prenom, string mail);

        [OperationContract]
        void Delete(User user);
    }
}
