using Common.Helpers;
using Common.Repositories.DeviceRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DeviceRepositoriesImplementation
{
    public class DeviceSqlServerRepository : IDeviceRepository
    {
        public DataContracts.Device GetById(int id)
        {
            string query = string.Format("SELECT * FROM DEVICE WHERE id={0};", id);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapDEVICE(reader).FirstOrDefault();
                }
            }
        }

        public List<DataContracts.Device> GetAll()
        {
            string query = string.Format("SELECT * FROM DEVICE");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    return MapDEVICE(reader);
                }
            }
        }

        public void Insert(DataContracts.Device entity)
        {
            string query = string.Format("INSERT INTO DEVICE(type, uniqueIdentifier, userId) VALUES('{0}', '{1}', '{2}');", entity.type, entity.uniqueIdentifier, entity.userId);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DataContracts.Device entity)
        {
            string query = string.Format("UPDATE DEVICE SET type='{1}', uniqueIdentifier='{2}', userId={3} WHERE id={0};",
                entity.ID,
                entity.type,
                entity.uniqueIdentifier,
                entity.userId);

            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DataContracts.Device entity)
        {
            string query = string.Format("DELETE FROM DEVICE WHERE id={0};", entity.ID);
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        private List<Device> MapDEVICE(IDataReader dataReader)
        {
            List<Device> list = new List<Device>();
            while (dataReader.Read())
            {
                Device device = new Device()
                {
                    ID = Tools.ChangeType<int>(dataReader["id"]),
                    type = Tools.ChangeType<string>(dataReader["type"]),
                    uniqueIdentifier = Tools.ChangeType<string>(dataReader["uniqueIdentifier"]),
                    userId = Tools.ChangeType<int>(dataReader["userId"])
                };
                list.Add(device);
            }
            return list;
        }
    }
}
