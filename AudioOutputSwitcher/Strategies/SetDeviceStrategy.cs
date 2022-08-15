namespace AudioOutputSwitcher.Strategies
{
    using System;
    using System.Threading.Tasks;
    using AudioSwitcher.AudioApi;

    public class SetDeviceStrategy : IStrategy
    {
        private readonly IAudioController audioController;

        public SetDeviceStrategy(IAudioController audioController)
        {
            this.audioController = audioController;
        }

        public async Task Handle(string[] args)
        {
            var id = args[1];
            Guid deviceId;
            if (id is null || !Guid.TryParse(id, out deviceId))
            {
                throw new ArgumentException("Device ID cannot be null");
            }

            var device = await this.audioController.GetDeviceAsync(deviceId);
            await device.SetAsDefaultAsync();
        }
    }
}
