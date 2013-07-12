using Common.Repositories.ProductRepository;
using DataAccess.UserProductsRepositoriesImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.UserProductsService
{
    public class UserProductsService : IUserProductsService
    {
        IUserProductsRepository _repo = new UserProductsSqlServerRepository();

        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            return _repo.GetByUserId(userId);
        }

        public DataContracts.UserProducts GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<DataContracts.UserProducts> GetAll()
        {
            return _repo.GetAll();
        }

        public void Insert(DataContracts.UserProducts entity)
        {
            _repo.Insert(entity);
        }

        public void Update(DataContracts.UserProducts entity)
        {
            _repo.Update(entity);
        }

        public void Delete(DataContracts.UserProducts entity)
        {
            _repo.Delete(entity);
        }
    }
}
