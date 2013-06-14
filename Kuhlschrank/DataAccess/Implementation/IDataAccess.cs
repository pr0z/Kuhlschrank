using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataAccess.Implementation
{
    public interface IDataAccess<T> where T : Entity
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
