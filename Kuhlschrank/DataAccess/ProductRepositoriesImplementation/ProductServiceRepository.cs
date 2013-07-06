using Common.Repositories.ProductRepository;
using DataAccess.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductRepositoriesImplementation
{
    public class ProductServiceRepository : IProductRepository
    {
        public DataContracts.Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.Product> GetAll()
        {
            return MyWebServices.ProductService.GetAll();
        }

        public void Insert(DataContracts.Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DataContracts.Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DataContracts.Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
