using Common.Helpers;
using Common.Repositories.ProductRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserProductsRepositoriesImplementation
{
    public class UserProductsSqlServerRepository : IUserProductsRepository
    {
        public List<DataContracts.UserProducts> GetByUserId(int userId)
        {
            string query = string.Format("SELECT * FROM USERPRODUCTS WHERE idUser='{0}';", userId);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERPRODUCTS(reader);
                }
            }
        }

        public DataContracts.UserProducts GetById(int id)
        {
            string query = string.Format("SELECT * FROM USERPRODUCTS WHERE id='{0}';", id);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERPRODUCTS(reader).FirstOrDefault();
                }
            }
        }

        public List<DataContracts.UserProducts> GetAll()
        {
            string query = string.Format("SELECT * FROM USERPRODUCTS;");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERPRODUCTS(reader);
                }
            }
        }

        public void Insert(DataContracts.UserProducts entity)
        {
            string query = string.Format("INSERT INTO USERPRODUCTS(idProduct, idUser, quantity) VALUES('{0}', '{1}', '{2}');", entity.IdProduct, entity.IdUser, entity.Quantity);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DataContracts.UserProducts entity)
        {
            string query = string.Format("UPDATE USERPRODUCTS SET idProduct = {0}, idUser = {1}, quantity = {2};", entity.IdUser, entity.IdUser, entity.Quantity);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DataContracts.UserProducts entity)
        {
            string query = string.Format("DELETE FROM USERPRODUCTS WHERE id = {0};", entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        private List<UserProducts> MapUSERPRODUCTS(IDataReader reader)
        {
            List<UserProducts> list = new List<UserProducts>();
            while (reader.Read())
            {
                UserProducts userproducts = new UserProducts()
                {
                    IdUser = Tools.ChangeType<int>(reader["idUser"]),
                    IdProduct = Tools.ChangeType<int>(reader["idProduct"]),
                    Quantity = Tools.ChangeType<int>(reader["quantity"]),
                };
                list.Add(userproducts);
            }
            return list;
        }
    }
}
