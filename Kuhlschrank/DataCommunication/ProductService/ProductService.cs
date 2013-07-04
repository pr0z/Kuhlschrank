using Common.Repositories.ProductRepository;
using DataAccess.ProductRepositoriesImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.ProductService
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo = new ProductListRepository();

        public List<DataContracts.Product> GetAll()
        {
            return _productRepo.GetAll();
        }
    }
}
