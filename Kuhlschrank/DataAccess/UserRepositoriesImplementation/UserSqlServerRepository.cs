using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataContracts;
using Common.Helpers;
using Common.Repositories.UserRepository;

namespace DataAccess.UserRepositoriesImplementation
{
    public class UserSqlServerRepository : IUserRepository
    {
        public User GetUserFromIdAndPassword(string identifier, string password)
        {
            string query = string.Format("SELECT * FROM USER WHERE mail={0};", identifier);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERSbo(reader).FirstOrDefault();
                }
            }
        }

        public User GetById(int id)
        {
            string query = string.Format("SELECT * FROM USER WHERE id={0};", id);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERSbo(reader).FirstOrDefault();
                }
            }
        }

        public List<User> GetAll()
        {
            string query = string.Format("SELECT * FROM USERS");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapUSERSbo(reader);
                }
            }
        }

        public void Insert(User entity)
        {
            string query = string.Format("INSERT INTO USER(nom, prenom, mail, pass) VALUES('{0}', '{1}', '{2}', '{3}');", entity.Nom, entity.Prenom, entity.Mail, entity.Password);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(User entity)
        {
            string query = string.Format("UPDATE USER SET nom='{0}', prenom='{1}', mail='{2}', pass='{3}' WHERE id={4};", entity.Nom, entity.Prenom, entity.Mail, entity.Password, entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(User entity)
        {
            string query = string.Format("DELETE FROM USER WHERE id={0};", entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        private List<User> MapUSERSbo(IDataReader dataReader)
        {
            List<User> list = new List<User>();
            while (dataReader.Read())
            {
                User user = new User()
                {
                    ID = Tools.ChangeType<int>(dataReader["id"]),
                    Nom = Tools.ChangeType<string>(dataReader["nom"]),
                    Prenom = Tools.ChangeType<string>(dataReader["prenom"]),
                    Mail = Tools.ChangeType<string>(dataReader["mail"]),
                    Password = Tools.ChangeType<string>(dataReader["pass"])
                };
                list.Add(user);
            }
            return list;
        }
    }
}
