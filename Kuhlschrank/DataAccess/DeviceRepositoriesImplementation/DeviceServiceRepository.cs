using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.DeviceRepository;
using DataAccess.WebServices;

namespace DataAccess.DeviceRepositoriesImplementation
{
    public class DeviceServiceRepository : IDeviceRepository
    {
        #region IRepository<Device> Membres

        public DataContracts.Device GetById(int id)
        {
            return MyWebServices.DeviceService.GetById(id);
        }

        public List<DataContracts.Device> GetAll()
        {
            return MyWebServices.DeviceService.GetAll();
        }

        public void Insert(DataContracts.Device entity)
        {
            MyWebServices.DeviceService.Insert(entity);
        }

        public void Update(DataContracts.Device entity)
        {
            MyWebServices.DeviceService.Update(entity);
        }

        public void Delete(DataContracts.Device entity)
        {
            MyWebServices.DeviceService.Delete(entity);
        }

        #endregion
    }
}
