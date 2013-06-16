using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class BaseCrud : IDisposable
    {
        protected string _connectionString;
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["RomanLocalDb"].ConnectionString;
                }
                return _connectionString;
            }
        }

        public SqlConnection Connection;

        public BaseCrud()
            : base()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            Debug.Write("connection opened");
        }

        protected bool IsDisposed { get; set; }

        public void Dispose()
        {

        }
    }
}
