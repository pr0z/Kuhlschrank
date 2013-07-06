using Common.Repositories;
using DataContracts;
using System;
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataContracts;
using Common.Helpers;
using Common.Repositories.CategoryRepository;

namespace DataAccess.CategoryRepositoriesImplementation
{
    public class CategorySqlServerRepository : ICategoryRepository
    {
        public Category GetById(int id)
        {
            string query = string.Format("SELECT * FROM CATEGORY WHERE id={0};", id);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapCATEGORYbo(reader).FirstOrDefault();
                }
            }           
        }

        public List<Category> GetAll()
        {
            string query = string.Format("SELECT * FROM CATEGORY");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapCATEGORYbo(reader);
                }
            }
        }

        public void Insert(Category entity)
        {
            string query = string.Format("INSERT INTO CATEGORY(libelle) VALUES('{0}');", entity.Libelle);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Category entity)
        {
            string query = string.Format("UPDATE CATEGORY SET libelle='{0}' WHERE id={1};", entity.Libelle, entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Category entity)
        {
            string query = string.Format("DELETE FROM CATEGORY WHERE id={0};", entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        private List<Category> MapCATEGORYbo(IDataReader dataReader)
        {
            List<Category> list = new List<Category>();
            while (dataReader.Read())
            {
                Category category = new Category()
                {
                    ID = Tools.ChangeType<int>(dataReader["id"]),
                    Libelle = Tools.ChangeType<string>(dataReader["libelle"]),
                };
                list.Add(category);
            }
            return list;
        }
    }
}
