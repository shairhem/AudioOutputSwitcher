namespace AudioOutputSwitcher.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AudioSwitcher.AudioApi;

    public class ListDevicesStrategy : IStrategy
    {
        private readonly IAudioController audioController;

        public ListDevicesStrategy(IAudioController audioController)
        {
            this.audioController = audioController;
        }

        public async Task Handle(string[] args)
        {
            IEnumerable<IDevice> devices = await this.audioController.GetPlaybackDevicesAsync(DeviceState.Active);
            foreach (var device in devices)
            {
                Console.WriteLine($"device id: {device.Id}");
                Console.WriteLine($"name: {device.FullName} \n");
            }
        }
    }
}
