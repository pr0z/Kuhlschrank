using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace DataAccess.Implementation
{
    public static class SqlManager
    {
        #region Variables
        private static SqlConnection _connection;
        private static SqlFactory.SqlFactory _factory;
        #endregion

        #region Props
        public static SqlConnection Connection
        {
            get
            {
                return _connection ?? (_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KUHLSHRANK"].ConnectionString));
            }
        }
        public static SqlFactory.SqlFactory SqlFactory
        {
            get
            {
                return _factory ?? (_factory = new SqlFactory.SqlFactory(Assembly.GetAssembly(typeof(User))));
            }
        }
        #endregion
    }
}
