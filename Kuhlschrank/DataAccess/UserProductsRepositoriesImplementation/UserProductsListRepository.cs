using Common.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataAccess.UserProductsRepositoriesImplementation
{
    class UserProductsListRepository : IUserProductsRepository
    {
        List<UserProducts> _source = new List<UserProducts>();

        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            return _source.Where(o => o.IdUser == userId).ToList();
        }

        public DataContracts.UserProducts GetById(int id)
        {
            throw new Exception("Un objet de type UserProduct n'a pas d'ID");
        }

        public List<DataContracts.UserProducts> GetAll()
        {
            return _source;
        }

        public void Insert(DataContracts.UserProducts entity)
        {
            _source.Add(entity);
        }

        public void Update(DataContracts.UserProducts entity)
        {
            UserProducts up = _source.First(o => o.IdProduct == entity.IdProduct && o.IdUser == entity.IdUser);
            if (up != null)
            {
                up.Quantity = entity.Quantity;
            }
        }

        public void Delete(DataContracts.UserProducts entity)
        {
            _source.RemoveAll(o => o.IdProduct == entity.IdProduct && o.IdUser == entity.IdUser);
        }
    }
}
