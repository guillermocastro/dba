using Dapper;
using dba.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace dba.Services
{
    public interface IDbaService
    {
        /*Config*/
        Task<List<Config>> GetConfig();
        Task<string> UpdateConfig(Config config);
        Task<string> DeleteConfig(Config config);
        Task<string> CreateConfig(Config config);
        /*SqlServer*/
        Task<List<SqlServer>> GetSqlServer();
        Task<string> UpdateSqlServer(SqlServer sqlserver);
        Task<string> DeleteSqlServer(SqlServer sqlserver);
        Task<string> CreateSqlServer(SqlServer sqlserver);
        /*SqlPatch*/
        Task<List<SqlPatch>> GetSqlPatch();
        Task<string> UpdateSqlPatch(SqlPatch sqlpatch);
        Task<string> DeleteSqlPatch(SqlPatch sqlpatch);
        Task<string> CreateSqlPatch(SqlPatch sqlpatch);
        /*Instance*/
        Task<List<Instance>> GetInstance();
        Task<string> UpdateInstance(Instance instance);
        Task<string> DeleteInstance(Instance instance);
        Task<string> CreateInstance(Instance instance);
        /*Snapshots*/
        /*DbBackup*/
        Task<List<DbBackup>> GetDbBackup();
        Task<string> UpdateDbBackup(DbBackup dbbackup);
        Task<string> DeleteDbBackup(DbBackup dbbackup);
        Task<string> CreateDbBackup(DbBackup dbbackup);
        /*Restore*/
        Task<List<Restore>> GetRestore();
        Task<string> UpdateRestore(Restore restore);
        Task<string> DeleteRestore(Restore restore);
        Task<string> CreateRestore(Restore restore);
        /*Db*/
        Task<List<Db>> GetDb();
        Task<string> UpdateDb(Db db);
        Task<string> DeleteDb(Db db);
        Task<string> CreateDb(Db db);
        /*DbFile*/
        Task<List<DbFile>> GetDbFile();
        Task<string> UpdateDbFile(DbFile dbfile);
        Task<string> DeleteDbFile(DbFile dbfile);
        Task<string> CreateDbFile(DbFile dbfile);
        /*DbTable*/
        Task<List<DbTable>> GetDbTable();
        Task<string> UpdateDbTable(DbTable dbtable);
        Task<string> DeleteDbTable(DbTable dbtable);
        Task<string> CreateDbTable(DbTable dbtable);
        /*Device*/
        Task<List<Device>> GetDevice();
        Task<string> UpdateDevice(Device device);
        Task<string> DeleteDevice(Device device);
        Task<string> CreateDevice(Device device);
        /*Disk*/
        Task<List<Disk>> GetDisk();
        Task<string> UpdateDisk(Disk disk);
        Task<string> DeleteDisk(Disk disk);
        Task<string> CreateDisk(Disk disk);
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