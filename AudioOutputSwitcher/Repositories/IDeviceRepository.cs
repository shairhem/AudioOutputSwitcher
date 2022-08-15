using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AudioOutputSwitcher.Models;

namespace AudioOutputSwitcher.Repositories
{
    public interface IDeviceRepository
    {
        Task SaveDevicesAsync(ICollection<Device> devices);

        Task<ICollection<Device>> GetDevicesAsync();

        Task<Device> GetDeviceAsync(int id);
    }
}
