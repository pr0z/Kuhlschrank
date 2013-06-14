using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using SqlFactory;

namespace DataAccess.Implementation
{
    public class SqlServerAccess<T> : IDataAccess<T> where T : Entity
    {
        private static SqlConnection _connection;

        private static SqlConnection SqlConnection
        {
            get
            {
                return _connection ?? (_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RomanLocalDb"].ConnectionString));
            }
        }

        public void Insert(T entity)
        {
            SqlCommand command = SqlConnection.CreateCommand();
            command.CommandText = SqlManager.SqlFactory.BuildSqlCommand<T>(entity, CommandType.Insert);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
