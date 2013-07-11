using Common.Repositories.DeviceRepository;
using DataAccess.DeviceRepositoriesImplementation;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommunication.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository _repo = new DeviceSqlServerRepository();

        public bool CheckRegistration(string uniqueIdentifier, int userId)
        {
            return _repo.GetAll().Where(o => o.uniqueIdentifier == uniqueIdentifier && o.userId == userId).FirstOrDefault() != null;
        }

        public DataContracts.Device GetById(int id)
        {
            return _repo.GetAll().Where(o => o.ID == id).FirstOrDefault();
        }

        public List<DataContracts.Device> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Device> GetByUserId(int userId)
        {
            return _repo.GetAll().Where(o => o.userId == userId).ToList();
        }

        public void Register(string type, string uniqueIdentifier, int userId)
        {
            Insert(new Device()
            {
                type = type,
                uniqueIdentifier = uniqueIdentifier,
                userId = userId
            });
        }

        public void Update(DataContracts.Device device)
        {
            _repo.Update(device);
        }

        public void Delete(string uniqueIdentifier)
        {
            Device item = _repo.GetAll().Where(o => o.uniqueIdentifier == uniqueIdentifier).FirstOrDefault();
            if (item != null)
            {
                Delete(item);
            }
        }


        public void Insert(Device entity)
        {
            _repo.Insert(entity);
        }

        public void Delete(Device entity)
        {
            _repo.Delete(entity);
        }
    }
}
