using Common.Repositories.DeviceRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.DeviceService
{
    [ServiceContract]
    public interface IDeviceService : IDeviceRepository
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<Device> GetAll();

        [OperationContract]
        new Device GetById(int id);

        [OperationContract]
        new List<Device> GetByUserId(int userId);

        [OperationContract]
        new void Delete(Device entity);

        [OperationContract]
        new void Update(Device entity);

        [OperationContract]
        new void Insert(Device entity);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "checkFromIandU?i={uniqueIdentifier}&u={userId}")]
        bool CheckRegistration(string uniqueIdentifier, int userId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "registerDevice?type={type}&uid={uniqueIdentifier}&userId={userId}")]
        void Register(string type, string uniqueIdentifier, int userId);

        [OperationContract(Name = "rest_delete")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "deleteDevice?uid={uniqueIdentifier}")]
        void Delete(string uniqueIdentifier);
    }
}
