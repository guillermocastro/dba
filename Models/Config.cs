using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dba.Models
{
    [Table("Config", Schema="dba")]
    public partial class Config
    {
        [Key]
        [StringLength(20)]
        public string VersionId { get; set; } = null!;
        [StringLength(64)]
        public string? License { get; set; }=null;
        [StringLength(256)]
        public string DailyBackup { get; set; } = null!;
        [StringLength(256)]
        public string WeeklyBackup { get; set; } = null!;
        [StringLength(256)]
        public string MonthlyBackup { get; set; } = null!;
        [StringLength(256)]
        public string Yearly4Backup { get; set; } = null!;
        [StringLength(256)]
        public string Yearly7Backup { get; set; } = null!;
        [StringLength(256)]
        public string ChangesBackup { get; set; } = null!;
    }
}
