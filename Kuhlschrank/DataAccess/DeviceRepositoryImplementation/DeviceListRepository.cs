using Common.Repositories.DeviceRepository;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DeviceRepositoryImplementation
{
    public class DeviceListRepository : IDeviceRepository
    {
        private static List<Device> _source;

        public DataContracts.Device GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Delete(DataContracts.Device entity)
        {
            throw new NotImplementedException();
        }
    }
}
