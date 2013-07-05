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
    public interface IDeviceService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "checkFromIandU?i={uniqueIdentifier}&u={userId}")]
        bool CheckRegistration(string uniqueIdentifier, int userId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Device GetById(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Device> GetAll();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "registerDevice?type={type}&uid={uniqueIdentifier}&userId={userId}")]
        void Register(string type, string uniqueIdentifier, int userId);

        [OperationContract]
        void Update(Device device);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "deleteDevice?uid={uniqueIdentifier}")]
        void Delete(string uniqueIdentifier);
    }
}
