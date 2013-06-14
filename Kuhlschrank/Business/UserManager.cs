using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementation;
using DataAccess.Repository;
using DataContracts;

namespace Business
{
    public class UserManager : Repository<User>
    {
        public UserManager()
            : base(new ListDataAccess<User>())
        {

        }

        public User GetUserFromIdAndPassword(string identifier, string password)
        {
            return _source.Where(o => o.Mail == identifier).FirstOrDefault();
        }

        //public User GetUserFromIdAndPassword(string identifier, string password)
        //{
        //    SqlCommand cmd = new SqlCommand("select * from USERS where USERS_MAIL = '" + identifier + "'", base.Connection);
        //    using (IDataReader reader = cmd.ExecuteReader())
        //    {
        //        var returnValue = MapUSERSbo(reader).FirstOrDefault();
        //        if (returnValue != null)
        //            return returnValue;
        //        else
        //            return null;
        //    }
        //}

        //public List<User> MapUSERSbo(IDataReader dataReader)
        //{
        //    List<User> list = new List<User>();

        //    while (dataReader.Read())
        //    {
        //        User user = new User()
        //        {
        //            Id = Tools.ChangeType<int>(dataReader["USERS_ID"]),
        //            Nom = Tools.ChangeType<string>(dataReader["USERS_NOM"]),
        //            Prenom = Tools.ChangeType<string>(dataReader["USERS_PRENOM"]),
        //            Mail = Tools.ChangeType<string>(dataReader["USERS_MAIL"]),
        //            Password = Tools.ChangeType<string>(dataReader["USERS_PASSWORD"])
        //        };

        //        list.Add(user);
        //    }

        //    return list;
        //}
    }
}
