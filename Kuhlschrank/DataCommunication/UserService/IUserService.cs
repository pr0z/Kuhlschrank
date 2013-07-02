﻿using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataContracts;

namespace DataCommunication.UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUserFromIdAndPassword(string identifier, string password);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        List<User> GetAll();

        [OperationContract]
        void Insert(User user);

        [OperationContract]
        void Update(User user);

        [OperationContract]
        void Delete(User user);
    }
}
