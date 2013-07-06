using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.CategoryRepository;
using DataAccess.WebServices;

namespace DataAccess.CategoryRepositoriesImplementation
{
    public class CategoryServiceRepository : ICategoryRepository
    {
        #region IRepository<Category> Membres

        public DataContracts.Category GetById(int id)
        {
            return MyWebServices.CategoryService.GetById(id);
        }

        public List<DataContracts.Category> GetAll()
        {
            return MyWebServices.CategoryService.GetAll();
        }

        public void Insert(DataContracts.Category entity)
        {
            MyWebServices.CategoryService.Insert(entity);
        }

        public void Update(DataContracts.Category entity)
        {
            MyWebServices.CategoryService.Update(entity);
        }

        public void Delete(DataContracts.Category entity)
        {
            MyWebServices.CategoryService.Delete(entity);
        }

        #endregion
    }
}
