using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.ProductRepository;

namespace DataCommunication.ProductService
{
    [ServiceContract]
    public interface IProductService : IProductRepository
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<Product> GetAll();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new Product GetById(int id);

        [OperationContract]
        new void Insert(Product entity);

        [OperationContract]
        new void Update(Product entity);

        [OperationContract]
        new void Delete(Product entity);
    }
}
