using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.ProductRepository;
using DataContracts;

namespace DataCommunication.UserProductService
{
    [ServiceContract]
    public interface IUserProductService : IUserProductsRepository
    {
        [OperationContract]
        List<UserProducts> GetAll();

        [OperationContract]
        void Insert(UserProducts entity);

        [OperationContract]
        void Update(UserProducts entity);

        [OperationContract]
        void Delete(UserProducts entity);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<UserProducts> GetByUserId(int userId);
    }
}
