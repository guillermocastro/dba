using dba.Models;

namespace dba.Services
{
    public interface IDbaService
    {
        /*Config*/
        Task<List<Config>> GetConfigs();
        Task<string> UpdateConfigs(Config config);
        Task<string> DeleteConfigs(Config config);
        Task<string> CreateConfigs(Config config);
        /*SqlServer*/
        /*SqlPatch*/
        /*Instance*/
        /*Snapshots*/
        /*DbBackup*/
        /*Restore*/
        /*Db*/
        /*DbFile*/
        /*DbTable*/
        /*Device*/
        Task<List<Device>> GetDevices();
        Task<string> UpdateDevices(Device device);
        Task<string> DeleteDevices(Device device);
        Task<string> CreateDevices(Device device);
        /*Disk*/
        /*Scripts*/
        /*Jobs*/
        /*Schedules*/
        /*Changes*/
        /*BackupFile*/
        /*Scripts*/
        /*DuplicatedIndex*/
        /*IndexFragmentation*/
        /*MissingIndex*/
    }
}