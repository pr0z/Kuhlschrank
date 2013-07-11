using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.DeviceRepository
{
    /// <summary>
    /// Contrat du Repository Device
    /// </summary>
    public interface IDeviceRepository : IRepository<Device>
    {
        List<DataContracts.Device> GetByUserId(int userId);
    }
}
