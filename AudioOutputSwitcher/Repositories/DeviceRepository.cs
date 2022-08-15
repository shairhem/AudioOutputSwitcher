namespace AudioOutputSwitcher.Repositories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AudioOutputSwitcher.Models;
    using Newtonsoft.Json;

    public class DeviceRepository : IDeviceRepository
    {
        private readonly string filename = "devices.json";

        public async Task<ICollection<Device>> GetDevicesAsync()
        {
            var json = await File.ReadAllTextAsync(this.filename);
            return JsonConvert.DeserializeObject<ICollection<Device>>(json);
        }

        public async Task<Device> GetDeviceAsync(int id)
        {
            var devices = await this.GetDevicesAsync();
            return devices.FirstOrDefault(device => device.Id == id);
        }

        public async Task SaveDevicesAsync(ICollection<Device> devices)
        {
            var json = JsonConvert.SerializeObject(devices, Formatting.Indented);
            await File.WriteAllTextAsync(this.filename, json);
        }
    }
}
