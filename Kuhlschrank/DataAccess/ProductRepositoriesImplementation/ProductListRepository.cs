using Common.Repositories.ProductRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductRepositoriesImplementation
{
    public class ProductListRepository : IProductRepository
    {
        private static List<Product> _source;

        public ProductListRepository()
        {
            if (_source == null)
            {
                _source = new List<Product>();
                for (int i = 0; i < 15; i++)
                {
                    Insert(new Product()
                    {
                        Id = i,
                        Libelle = "Produit " + i
                    });
                }
            }
        }

        public DataContracts.Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.Product> GetAll()
        {
            return _source;
        }

        public void Insert(DataContracts.Product entity)
        {
            _source.Add(entity);
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
