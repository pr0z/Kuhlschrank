using Common.Repositories.CategoryRepository;
using DataAccess.CategoryRepositoriesImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repo = new CategorySqlServerRepository();

        public DataContracts.Category GetById(int id)
        {
            return _repo.GetAll().Where(o => o.ID == id).FirstOrDefault();
        }

        public List<DataContracts.Category> GetAll()
        {
            return _repo.GetAll();
        }

        public void Insert(DataContracts.Category entity)
        {
            _repo.Insert(entity);
        }

        public void Update(DataContracts.Category entity)
        {
            _repo.Update(entity);
        }

        public void Delete(DataContracts.Category entity)
        {
            _repo.Delete(entity);
        }
    }
}
