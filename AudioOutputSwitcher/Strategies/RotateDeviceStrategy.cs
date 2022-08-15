namespace AudioOutputSwitcher.Strategies
{
    using System.Linq;
    using System.Threading.Tasks;
    using AudioSwitcher.AudioApi;

    public class RotateDeviceStrategy : IStrategy
    {
        private readonly IAudioController audioController;

        public RotateDeviceStrategy(IAudioController audioController)
        {
            this.audioController = audioController;
        }

        public async Task Handle(string[] args)
        {
            var currentDevice = await this.audioController.GetDefaultDeviceAsync(DeviceType.Playback, Role.Multimedia);
            var devices = (await this.audioController.GetPlaybackDevicesAsync(DeviceState.Active)).ToList();
            var index = devices.FindIndex(x => x.Id == currentDevice.Id);
            var nextIndex = ++index > devices.Count - 1 ? 0 : index;
            await devices[nextIndex].SetAsDefaultAsync();
        }
    }
}
