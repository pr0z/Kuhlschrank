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
    }
}
