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
            return "ojo";
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
        public async Task<string> CreateDeviceAsync(Device devicey)
        {
            return "ojo";
        }
    }
}