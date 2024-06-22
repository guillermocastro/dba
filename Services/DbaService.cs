using dba.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using dba.Components.Pages;
namespace dba.Services
{
    public class DbaService : IDbaService
    {
        private readonly IConfiguration _configuration;
        public DbaService(IConfiguration _config)
        {
            _configuration = _config;
        }

        /*Config*/
        public async Task<List<dba.Models.Config>> GetConfig()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Config]";
                IEnumerable<dba.Models.Config> dataList = await con.QueryAsync<dba.Models.Config>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateConfig(dba.Models.Config config){
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
        public async Task<string> DeleteConfig(dba.Models.Config config)
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
        public async Task<string> CreateConfig(dba.Models.Config config)
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
        public async Task<List<SqlServer>> GetSqlServer()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[SqlServer]";
                IEnumerable<SqlServer> dataList = await con.QueryAsync<SqlServer>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateSqlServer(SqlServer sqlserver)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"UPDATE [dba].[SqlServer] SET [SqlServerVersion]=@SqlServerVersion WHERE SqlServerId=@SqlServerId";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlserver.SqlServerId, sqlserver.SqlServerVersion }, commandType: CommandType.Text);
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
        public async Task<string> DeleteSqlServer(SqlServer sqlserver)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = @"DELETE FROM [dba].[SqlServer] WHERE [SqlServerId]=@SqlServerId";
                parameters.Add("@SqlServerId", sqlserver.SqlServerId);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlserver.SqlServerId, sqlserver.SqlServerVersion }, commandType: CommandType.Text);
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
        public async Task<string> CreateSqlServer(SqlServer sqlserver)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"INSERT INTO [dba].[SqlServer] ([SqlServerId],[SqlServerVersion]) VALUES (@SqlServerId,@SqlServerVersion)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlserver.SqlServerId, sqlserver.SqlServerVersion }, commandType: CommandType.Text);
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
        /*SqlPatch*/
        public async Task<List<SqlPatch>> GetSqlPatch()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[SqlPatch]";
                IEnumerable<SqlPatch> dataList = await con.QueryAsync<SqlPatch>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateSqlPatch(SqlPatch sqlpatch)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"UPDATE [dba].[SqlPatch] SET [SqlServerId]=@SqlServerId, [Cun]=@Cun, [SqlPatchDate]=@SqlPatchDate, [PatchStatus]=@PatchStatus WHERE SqlPatchId=@SqlPatchId";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlpatch.SqlPatchId, sqlpatch.SqlServerId, sqlpatch.Cun, sqlpatch.SqlPatchDate, sqlpatch.PatchStatus }, commandType: CommandType.Text);
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
        public async Task<string> DeleteSqlPatch(SqlPatch sqlpatch)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = @"DELETE FROM [dba].[SqlPatch] WHERE [SqlPatchId]=@SqlPatchId";
                parameters.Add("@SqlServerId", sqlpatch.SqlPatchId);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlpatch.SqlPatchId, sqlpatch.SqlServerId, sqlpatch.Cun, sqlpatch.SqlPatchDate, sqlpatch.PatchStatus }, commandType: CommandType.Text);
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
        public async Task<string> CreateSqlPatch(SqlPatch sqlpatch)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                const string sqlquery = @"INSERT INTO [dba].[SqlPatch] ([SqlPatchId],[SqlServerId],[Cun],[SQLPatchDate],[PatchStatus ]) VALUES (@[SqlPatchId,@SqlServerId,@Cun,@SQLPatchDate,@PatchStatus)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(sqlquery, new { sqlpatch.SqlPatchId, sqlpatch.SqlServerId, sqlpatch.Cun, sqlpatch.SqlPatchDate, sqlpatch.PatchStatus }, commandType: CommandType.Text);
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
        /*Instance*/
        public async Task<List<Instance>> GetInstance()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Instance]";
                IEnumerable<Instance> dataList = await con.QueryAsync<Instance>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateInstance(Instance instance)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteInstance(Instance instance)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateInstance(Instance instance)
        {
            throw new NotImplementedException();
        }
        /*Snapshots*/
        /*DbBackup*/
        public async Task<List<DbBackup>> GetDbBackup()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[DbBackup]";
                IEnumerable<DbBackup> dataList = await con.QueryAsync<DbBackup>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDbBackup(DbBackup dbbackup)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteDbBackup(DbBackup dbbackup)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateDbBackup(DbBackup dbbackup)
        {
            throw new NotImplementedException();
        }
        /*Restore*/
        public async Task<List<Restore>> GetRestore()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Restore]";
                IEnumerable<Restore> dataList = await con.QueryAsync<Restore>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateRestore(Restore restore)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteRestore(Restore restore)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateRestore(Restore restore)
        {
            throw new NotImplementedException();
        }
        /*Db*/
        public async Task<List<Db>> GetDb()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Db]";
                IEnumerable<Db> dataList = await con.QueryAsync<Db>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDb(Db db)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteDb(Db db)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateDb(Db db)
        {
            throw new NotImplementedException();
        }
        /*DbFile*/
        public async Task<List<DbFile>> GetDbFile()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[DbFile]";
                IEnumerable<DbFile> dataList = await con.QueryAsync<DbFile>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDbFile(DbFile dbfile)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteDbFile(DbFile dbfile)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateDbFile(DbFile dbfile)
        {
            throw new NotImplementedException();
        }
        /*DbTable*/
        public async Task<List<DbTable>> GetDbTable()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[DbTable]";
                IEnumerable<DbTable> dataList = await con.QueryAsync<DbTable>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public async Task<string> UpdateDbTable(DbTable dbtable)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteDbTable(DbTable dbtable)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateDbTable(DbTable dbtable)
        {
            throw new NotImplementedException();
        }
        /*Device*/
        public async Task<List<Device>> GetDevice()
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
        public async Task<List<Disk>> GetDisk()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                var sqlquery = "SELECT * FROM [dba].[Disk]";
                IEnumerable<Disk> dataList = await con.QueryAsync<Disk>(sqlquery, parameters, commandType: CommandType.Text);
                return dataList.ToList();
            }
        }
        public Task<string> UpdateDisk(Disk disk)
        {
            throw new NotImplementedException();
        }
        public Task<string> DeleteDisk(Disk disk)
        {
            throw new NotImplementedException();
        }
        public Task<string> CreateDisk(Disk disk)
        {
            throw new NotImplementedException();
        }
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