﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication
{
    public static class AccessBD
    {
        private static SqlConnection _connection;

        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == System.Data.ConnectionState.Closed || _connection.State == System.Data.ConnectionState.Broken)
                {
                    _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KUHLSCHRANK"].ConnectionString);
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}