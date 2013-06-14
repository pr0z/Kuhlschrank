using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataAccess.Implementation
{
    public class ListDataAccess<T> : IDataAccess<T> where T : Entity
    {
        List<T> _source;

        public ListDataAccess()
        {
            _source = new List<T>();
        }

        public void Insert(T entity)
        {
            _source.Add(entity);
        }

        public void Delete(T entity)
        {
            _source.Remove(GetById(entity.ID));
        }

        public void Update(T entity)
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(T) });
            T item = ctor.Invoke(new object[] { entity }) as T;
            if (item != null)
            {
                Delete(GetById(entity.ID));
                Insert(item);
            }
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _source.Where(predicate.Compile()).AsQueryable();
        }

        public IQueryable<T> GetAll()
        {
            return _source.AsQueryable();
        }

        public T GetById(int id)
        {
            return _source.Find(o => o.ID == id);
        }
    }
}
