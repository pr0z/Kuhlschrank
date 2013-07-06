using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataContracts;
using Common.Repositories.UserRepository;

namespace DataCommunication.UserService
{
    [ServiceContract]
    public interface IUserService : IUserRepository
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "fromIAndP?i={identifier}&p={password}")]
        new User GetUserFromIdAndPassword(string identifier, string password);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "getbyid?id={id}")]
        new User GetById(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<User> GetAll();

        [OperationContract]
        new void Insert(User user);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "updateUser?id={id}&n={nom}&f={prenom}&m={mail}")]
        void Update(int id, string nom, string prenom, string mail);

        [OperationContract]
        new void Delete(User user);
    }
}
