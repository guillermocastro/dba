using dba.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace dba.Services
{
    public class DbaService :IDbaService
    {
        private readonly IConfiguration _configuration;
        public DbaService(IConfiguration _config)
        {
            _configuration = _config;
        }
        public async Task<List<Device>> GetDevicesAsync()
        {
             using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Device]";
                IEnumerable<Device> dataList = await con.QueryAsync<Device>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDeviceAsync(Device device)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"UPDATE [dba].[Device] SET [Ram]=@Ram, [Cpu]=@Cpu, [Cores]=@Cores, [DataImportUtc]=GETUTCDATE() WHERE DeviceId=@DeviceId";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { device.DeviceId, device.Ram, device.Cpu, device.Cores, device.DataImportUtc }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return "Row updated";
        }
        public async Task<string> DeleteDeviceAsync(Device device)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = @"DELETE FROM [dba].[Device] WHERE [DeviceId]=@DeviceId";
                parameters.Add("@DeviceId", device.DeviceId);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { device.DeviceId }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return "Row deleted";
        }
        public async Task<string> CreateDeviceAsync(Device device)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"INSERT INTO [dba].[Device] ([DeviceId],[Ram],[Cpu],[Cores],[DataimportUtc]) VALUES (Ram, @Cpu, @Cores, GETUTCDATE())";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { device.DeviceId, device.Ram, device.Cpu, device.Cores, device.DataImportUtc }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
                return "Row Inserted";   
       }
    }
}