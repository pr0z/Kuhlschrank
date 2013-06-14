using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;

using DataContracts;
using DataAccess.Implementation;

namespace DataAccess.Repository
{
    public class Repository<T> : INotifyCollectionChanged, IEnumerable<T>, IRepository<T> where T : Entity
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected IDataAccess<T> _source;

        public Repository(IDataAccess<T> source)
        {
            _source = source;
        }

        public void Insert(T entity)
        {
            _source.Insert(entity);
            Notify(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Delete(T entity)
        {
            _source.Delete(entity);
            Notify(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Update(T entity)
        {
            _source.Update(entity);
            Notify(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _source.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _source.GetAll();
        }

        public T GetById(int id)
        {
            return _source.GetById(id);
        }

        private void Notify(NotifyCollectionChangedEventArgs arg)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, arg);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in GetAll())
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }
    }
}
