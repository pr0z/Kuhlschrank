using Common.Repositories.CategoryRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryRepositoriesImplementation
{
    public class CategoryListRepository : ICategoryRepository
    {
        private static List<Category> _source;
        public CategoryListRepository()
        {
            if (_source == null)
            {
                _source = new List<Category>
                {
                    new Category
                    {
                        ID = 0,
                        Libelle = "test"
                    }
                };
            }
        }

        public DataContracts.Category GetById(int id)
        {
            return _source.First(o => o.ID == id);
        }

        public List<DataContracts.Category> GetAll()
        {
            return _source;
        }

        public void Insert(DataContracts.Category entity)
        {
            _source.Add(entity);
        }

        public void Update(DataContracts.Category entity)
        {
            Category cat = _source.First(o => o.ID == entity.ID);
            if (cat != null)
            {
                cat.Libelle = entity.Libelle;
            }
        }

        public void Delete(DataContracts.Category entity)
        {
            _source.RemoveAll(o => o.ID == entity.ID);
        }
    }
}
