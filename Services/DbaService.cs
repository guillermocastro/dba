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
        /*Config*/
        public async Task<List<Config>> GetConfigs()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Config]";
                IEnumerable<Config> dataList = await con.QueryAsync<Config>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateConfigs(Config config){
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"UPDATE [dba].[Config] SET [DailyBackup]=@DailyBackup,[WeeklyBackup]=@WeeklyBackup,[MonthlyBackup]=@MonthlyBackup,[Yearly4Backup]=@Yearly4Backup,[Yearly7Backup]=@Yearly7Backup,[ChangesBackup]=@ChangesBackup,[License]=@License WHERE VersionId=@VersionId";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { config.VersionId,config.DailyBackup,config.WeeklyBackup,config.MonthlyBackup,config.Yearly4Backup,config.Yearly7Backup,config.ChangesBackup,config.License }, commandType: CommandType.Text);
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
        public async Task<string> DeleteConfigs(Config config)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = @"DELETE FROM [dba].[Config] WHERE [VersionId]=@VersionId";
                parameters.Add("@VersionId", config.VersionId);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { config.VersionId }, commandType: CommandType.Text);
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
        public async Task<string> CreateConfigs(Config config)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"INSERT INTO [dba].[Config] ([VersionId],[DailyBackup],[WeeklyBackup],[MonthlyBackup],[Yearly4Backup],[Yearly7Backup],[ChangesBackup],[License]) VALUES (@VersionId,@DailyBackup,@WeeklyBackup,@MonthlyBackup,@Yearly4Backup,@Yearly7Backup,@ChangesBackup,@License)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { config.VersionId,config.DailyBackup,config.WeeklyBackup,config.MonthlyBackup,config.Yearly4Backup,config.Yearly7Backup,config.ChangesBackup,config.License }, commandType: CommandType.Text);
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
        public async Task<List<Device>> GetDevices()
        {
             using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Device]";
                IEnumerable<Device> dataList = await con.QueryAsync<Device>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDevice(Device device)
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
        public async Task<string> DeleteDevice(Device device)
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
        public async Task<string> CreateDevice(Device device)
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