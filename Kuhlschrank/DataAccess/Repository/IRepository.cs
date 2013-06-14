using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
