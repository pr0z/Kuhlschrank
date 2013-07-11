using Common.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserProductsRepositoriesImplementation
{
    class UserProductsListRepository : IUserProductsRepository
    {
        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public DataContracts.UserProducts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.UserProducts> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(DataContracts.UserProducts entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DataContracts.UserProducts entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DataContracts.UserProducts entity)
        {
            throw new NotImplementedException();
        }
    }
}
