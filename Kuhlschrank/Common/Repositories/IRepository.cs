using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    /// <summary>
    /// Contrat dont tout les Repositories héritent
    /// </summary>
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
