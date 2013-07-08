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
                Random rdm = new Random();
                _source = new List<Product>();
                for (int i = 0; i < 15; i++)
                {
                    _source.Add(new Product()
                    {
                        ID = i,
                        Libelle = "Produit " + i,
                        IdCategory = rdm.Next(1, 4)
                    });
                }
            }
        }

        public DataContracts.Product GetById(int id)
        {
            return _source.First(o => o.ID == id);
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
            Product prod = _source.First(o => o.ID == entity.ID);
            if (prod != null)
            {
                prod.IdCategory = entity.IdCategory;
                prod.Libelle = entity.Libelle;
            }
        }

        public void Delete(DataContracts.Product entity)
        {
            _source.RemoveAll(o => o.ID == entity.ID);
        }

        public Product GetByEan13(string ean13)
        {
            return _source.Where(o => o.Code == ean13).FirstOrDefault();
        }
    }
}
