using Common.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.UserProductsService
{
    [ServiceContract]
    public interface IUserProductsService : IUserProductsRepository
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<DataContracts.UserProducts> GetByUserId(int userId);

        [OperationContract]
        new DataContracts.UserProducts GetById(int id);

        [OperationContract]
        new List<DataContracts.UserProducts> GetAll();

        [OperationContract]
        new void Insert(DataContracts.UserProducts entity);

        [OperationContract]
        new void Update(DataContracts.UserProducts entity);

        [OperationContract]
        new void Delete(DataContracts.UserProducts entity);
    }
}
