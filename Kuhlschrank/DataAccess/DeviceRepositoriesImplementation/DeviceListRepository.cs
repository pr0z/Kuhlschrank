using Common.Repositories.DeviceRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DeviceRepositoriesImplementation
{
    public class DeviceListRepository : IDeviceRepository
    {
        private static List<Device> _source;
        public DeviceListRepository()
        {
            if (_source == null)
            {
                _source = new List<Device>
                {
                    new Device
                    {
                        ID = 0,
                        type = "toto",
                        uniqueIdentifier = "rien",
                        userId = 0
                    }
                };
            }
        }

        public DataContracts.Device GetById(int id)
        {
            return _source.First(o => o.ID == id);
        }

        public List<DataContracts.Device> GetAll()
        {
            return _source;
        }

        public void Insert(DataContracts.Device entity)
        {
            _source.Add(entity);
        }

        public void Update(DataContracts.Device entity)
        {
            Device dev = _source.First(o => o.ID == entity.ID);
            if (dev != null)
            {
                dev.type = entity.type;
                dev.uniqueIdentifier = entity.uniqueIdentifier;
                dev.userId = entity.userId;
            }
        }

        public void Delete(DataContracts.Device entity)
        {
            _source.RemoveAll(o => o.ID == entity.ID);
        }

        public List<Device> GetByUserId(int userId)
        {
            return _source.Where(o => o.userId == userId).ToList();
        }
    }
}
