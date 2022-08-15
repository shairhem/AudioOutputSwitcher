namespace AudioOutputSwitcher.Services
{
    using System.Threading.Tasks;

    public interface IDeviceService
    {
        Task ReloadDevicesAsync();

        Task SetOuputDeviceByIdAsync(int id);

        Task RotateAsync();
    }
}
