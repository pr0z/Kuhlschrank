using Common.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.WebServices;

namespace DataAccess.UserProductsRepositoriesImplementation
{
    public class UserProductsServiceRepository : IUserProductsRepository
    {
        //public List<DataContracts.UserProducts> GetByUserId(int userId)
        //{
        //    return MyWebServices.UserProductsService.GetByUserId(userId);
        //}

        //public DataContracts.UserProducts GetById(int id)
        //{
        //    throw new Exception("Un objet de type UserProduct n'a pas d'ID");
        //}

        //public List<DataContracts.UserProducts> GetAll()
        //{
        //    return MyWebServices.UserProductsService.GetAll();
        //}

        //public void Insert(DataContracts.UserProducts entity)
        //{
        //    MyWebServices.UserProductsService.Insert(entity);
        //}

        //public void Update(DataContracts.UserProducts entity)
        //{
        //    MyWebServices.UserProductsService.Update(entity);
        //}

        //public void Delete(DataContracts.UserProducts entity)
        //{
        //    MyWebServices.UserProductsService.Delete(entity);
        //}
        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            return MyWebServices.UserProductService.GetByUserId(userId);
>>>>>>> ptite modif
        }

        public DataContracts.UserProducts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.UserProducts> GetAll()
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            return MyWebServices.UserProductService.GetAll();
>>>>>>> ptite modif
        }

        public void Insert(DataContracts.UserProducts entity)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            MyWebServices.UserProductService.Insert(entity);
>>>>>>> ptite modif
        }

        public void Update(DataContracts.UserProducts entity)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            MyWebServices.UserProductService.Update(entity);
>>>>>>> ptite modif
        }

        public void Delete(DataContracts.UserProducts entity)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            MyWebServices.UserProductService.Delete(entity);
>>>>>>> ptite modif
        }
    }
}
