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
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Config>().HasData(
                new Config { VersionId = "1.0.0", DailyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Daily", WeeklyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Weekly", MonthlyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Monthly", Yearly4Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 4year", Yearly7Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 7 year", ChangesBackup = "\\\\vamwin\\shares\\Changes" }
                );
        }
    }
}
