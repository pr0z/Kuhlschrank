using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.ProductRepository
{
    /// <summary>
    /// Contrat du Repository UserProducts
    /// </summary>
    public interface IUserProductsRepository : IRepository<UserProducts>
    {
        List<DataContracts.UserProducts> GetByUserId(int userId);
    }
}
