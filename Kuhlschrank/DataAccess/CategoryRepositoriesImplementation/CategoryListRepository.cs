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

        public DataContracts.Category GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Delete(DataContracts.Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
