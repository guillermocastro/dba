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
        public DbSet<Config>? Config { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Config>().HasData(
                new Config { VersionId = "1.0.0", DailyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Daily", WeeklyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Weekly", MonthlyBackup = "\\\\vamwin\\shares\\SQL Server Backups - Monthly", Yearly4Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 4year", Yearly7Backup = "\\\\vamwin\\shares\\SQL Server Backups - Annual - 7 year", ChangesBackup = "\\\\vamwin\\shares\\Changes" }
                );
        }
    }
}
