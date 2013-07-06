using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Helpers;
using Common.Repositories.ProductRepository;
using DataContracts;

namespace DataAccess.ProductRepositoriesImplementation
{
    public class ProductSqlServerRepository : IProductRepository
    {
        public DataContracts.Product GetById(int id)
        {
            string query = string.Format("SELECT * FROM PRODUCT WHERE id={0};", id);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapPRODUCTbo(reader).FirstOrDefault();
                }
            }
        }

        public List<DataContracts.Product> GetAll()
        {
            string query = string.Format("SELECT * FROM PRODUCT");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapPRODUCTbo(reader);
                }
            }
        }

        public void Insert(DataContracts.Product entity)
        {
            string query = string.Format("INSERT INTO PRODUCT(libelle, id_category) VALUES('{0}',{1});", entity.Libelle, entity.IdCategory);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DataContracts.Product entity)
        {
            string query = string.Format("UPDATE PRODUCT SET libelle='{0}', id_category={1} WHERE id={2};", entity.Libelle, entity.IdCategory, entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DataContracts.Product entity)
        {
            string query = string.Format("DELETE FROM PRODUCT WHERE id={0};", entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        private List<Product> MapPRODUCTbo(IDataReader dataReader)
        {
            List<Product> list = new List<Product>();
            while (dataReader.Read())
            {
                Product product = new Product()
                {
                    ID = Tools.ChangeType<int>(dataReader["id"]),
                    Libelle = Tools.ChangeType<string>(dataReader["libelle"]),
                    IdCategory = Tools.ChangeType<int>(dataReader["id_category"]),
                };
                list.Add(product);
            }
            return list;
        }
    }
}
