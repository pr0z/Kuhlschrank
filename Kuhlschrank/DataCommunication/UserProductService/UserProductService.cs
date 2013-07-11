using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.ProductRepository;
using DataAccess.UserProductsRepositoriesImplementation;

namespace DataCommunication.UserProductService
{
    public class UserProductService : IUserProductService
    {
        IUserProductsRepository _repo = new UserProductsSqlServerRepository();

        #region IRepository<UserProducts> Membres

        public DataContracts.UserProducts GetById(int id)
        {
            throw new Exception("Un objet de type UserProduct n'a pas d'ID");
        }

        #endregion

        #region IUserProductService Membres

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

        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            return _repo.GetByUserId(userId);
        }

        #endregion
    }
}
