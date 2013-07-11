﻿using Common.Repositories.ProductRepository;
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
        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            return MyWebServices.UserProductService.GetByUserId(userId);
        }

        public DataContracts.UserProducts GetById(int id)
        {
            throw new Exception("Un objet de type UserProduct n'a pas d'ID");
        }

        public List<DataContracts.UserProducts> GetAll()
        {
            return MyWebServices.UserProductService.GetAll();
        }

        public void Insert(DataContracts.UserProducts entity)
        {
            MyWebServices.UserProductService.Insert(entity);
        }

        public void Update(DataContracts.UserProducts entity)
        {
            MyWebServices.UserProductService.Update(entity);
        }

        public void Delete(DataContracts.UserProducts entity)
        {
            MyWebServices.UserProductService.Delete(entity);
        }
    }
}
