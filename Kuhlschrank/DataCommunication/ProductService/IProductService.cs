using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.ProductService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetAll();
    }
}
