namespace AudioOutputSwitcher
{
    using System.Linq;
    using AudioOutputSwitcher.Repositories;
    using AudioOutputSwitcher.Services;
    using AudioSwitcher.AudioApi.CoreAudio;

    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new CoreAudioController();
            var repository = new DeviceRepository();
            var service = new DeviceService(repository, controller);

            if (args.Length == 0)
            {
                service.RotateAsync().Wait();
            }
            else
            {
                var argument = args.First();
                int id;
                if (int.TryParse(argument, out id))
                {
                    service.SetOuputDeviceByIdAsync(id).Wait();
                } 
                else
                {
                    service.ReloadDevicesAsync().Wait();
                }
            }
        }
    }
}
