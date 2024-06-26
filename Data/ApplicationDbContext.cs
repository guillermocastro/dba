using dba.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Device>? Devices { get; set; }
        public DbSet<Disk>? Disks { get; set; }
        public DbSet<Instance>? Instances { get; set; }
        public DbSet<Config>? Config { get; set; }
        public DbSet<Db>? Db { get; set; }
        public DbSet<DbBackup>? DbBackup { get; set; }
        public DbSet<DbFile>? DbFile { get; set; }
        public DbSet<DbTable>? DbTable { get; set; }
        public DbSet<Restore>? Restore { get; set; }
        public DbSet<SqlPatch>? SqlPatch { get; set; }
        public DbSet<SqlServer>? SqlServer { get; set; }
        public DbSet<BackupFile> BackupFile  { get; set; }
        public DbSet<DuplicatedIndex> DuplicatedIndex { get; set; }
        public DbSet<IndexFragmentation> IndexFragmentation { get; set; }
        public DbSet<TableUsage> TableUsage { get; set; }
        public DbSet<UnusedIndex> UnusedIndex { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Config>().HasData(
                new Config { VersionId = "1.0.0", License = "473EF1B7-0514-4038-999F-8CD547AC0050", DailyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Daily", WeeklyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Weekly", MonthlyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Monthly", Yearly4Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 4year", Yearly7Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 7 year", ChangesBackup = "\\\\vamwin\\shares\\Changes" }
                );
            builder.Entity<SqlServer>().HasData(
                new SqlServer { SqlServerId = "12.0", SqlServerVersion = "Sql Server 2014" },
                new SqlServer { SqlServerId = "13.0", SqlServerVersion = "Sql Server 2016" },
                new SqlServer { SqlServerId = "14.0", SqlServerVersion = "Sql Server 2017" },
                new SqlServer { SqlServerId = "15.0", SqlServerVersion = "Sql Server 2019" },
                new SqlServer { SqlServerId = "16.0", SqlServerVersion = "Sql Server 2022" }
                );
        }
    }
}
