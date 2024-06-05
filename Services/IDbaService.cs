using dba.Models;

namespace dba.Services
{
    public interface IDbaService
    {
        /*Device*/
        Task<List<Device>> GetDevicesAsync();
        Task<string> UpdateDeviceAsync(Device device);
        Task<string> DeleteDeviceAsync(Device device);
        Task<string> CreateDeviceAsync(Device device);
    }
}