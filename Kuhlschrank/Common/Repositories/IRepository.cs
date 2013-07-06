using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    [ServiceContract]
    public interface IRepository<T>
    {
        [OperationContract]
        T GetById(int id);
        [OperationContract]
        List<T> GetAll();
        [OperationContract]
        void Insert(T entity);
        [OperationContract]
        void Update(T entity);
        [OperationContract]
        void Delete(T entity);
    }
}
