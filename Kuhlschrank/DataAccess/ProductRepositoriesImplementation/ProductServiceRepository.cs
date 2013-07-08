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
            return MyWebServices.ProductService.GetById(id);
        }

        public List<DataContracts.Product> GetAll()
        {
            return MyWebServices.ProductService.GetAll();
        }

        public void Insert(DataContracts.Product entity)
        {
            MyWebServices.ProductService.Insert(entity);
        }

        public void Update(DataContracts.Product entity)
        {
            MyWebServices.ProductService.Update(entity);
        }

        public void Delete(DataContracts.Product entity)
        {
            MyWebServices.ProductService.Delete(entity);
        }

        public DataContracts.Product GetByEan13(string ean13)
        {
            return MyWebServices.ProductService.GetByEan13(ean13);
        }
    }
}
