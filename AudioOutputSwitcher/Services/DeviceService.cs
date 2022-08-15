namespace AudioOutputSwitcher.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AudioOutputSwitcher.Repositories;
    using AudioSwitcher.AudioApi;
    using Models = AudioOutputSwitcher.Models;

    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly IAudioController audioController;

        public DeviceService(IDeviceRepository deviceRepository, IAudioController audioController)
        {
            this.deviceRepository = deviceRepository;
            this.audioController = audioController;
        }

        public async Task ReloadDevicesAsync()
        {
            IEnumerable<IDevice> devices = await this.audioController.GetPlaybackDevicesAsync(DeviceState.Active);
            ICollection<Models.Device> outputDevices = new List<Models.Device>();
            int index = 1;
            foreach (var device in devices)
            {
                Console.WriteLine($"id: {index}");
                Console.WriteLine($"device id: {device.Id}");
                Console.WriteLine($"name: {device.FullName} \n");

                outputDevices.Add(new Models.Device()
                {
                    Id = index++,
                    DeviceId = device.Id,
                    Name = device.FullName
                });
            }

            await this.deviceRepository.SaveDevicesAsync(outputDevices);
        }

        public async Task SetOuputDeviceByIdAsync(int id)
        {
            var outputDevice = await this.deviceRepository.GetDeviceAsync(id);
            var device = await this.audioController.GetDeviceAsync(outputDevice.DeviceId);
            await device.SetAsDefaultAsync();
        }
    }
}
