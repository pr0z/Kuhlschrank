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
        IProductRepository _productRepo = new ProductSqlServerRepository();

        public List<DataContracts.Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        #region IRepository<Product> Membres

        public DataContracts.Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }

        public void Insert(DataContracts.Product entity)
        {
            _productRepo.Insert(entity);
        }

        public void Update(DataContracts.Product entity)
        {
            _productRepo.Update(entity);
        }

        public void Delete(DataContracts.Product entity)
        {
            _productRepo.Delete(entity);
        }

        public DataContracts.Product GetByEan13(string ean13)
        {
            return _productRepo.GetByEan13(ean13);
        }
        #endregion
    }
}
