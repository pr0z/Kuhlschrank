using Common.Repositories.CategoryRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.CategoryService
{
    [ServiceContract]
    public interface ICategoryService : ICategoryRepository
    {
        [OperationContract]
        new Category GetById(int id);
        
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<Category> GetAll();

        [OperationContract]
        new void Insert(Category entity);

        [OperationContract]
        new void Update(Category entity);

        [OperationContract]
        new void Delete(Category entity);
    }
}
