﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Classe statique qui gère la connexion à la base de données
    /// </summary>
    public static class AccessBD
    {
        private static SqlConnection _connection;

        /// <summary>
        /// Retourne la connexion courante
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == System.Data.ConnectionState.Closed || _connection.State == System.Data.ConnectionState.Broken)
                {
                    _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LanDb"].ConnectionString);
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
