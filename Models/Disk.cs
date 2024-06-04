using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dba.Models
{
    [Table("Disk", Schema = "dba")]
    public partial class Disk
    {
        [StringLength(128)]
        public string DeviceId { get; set; } = null!;
        [StringLength(10)]
        public string? Drive { get; set; }
        [StringLength(18)]
        public string? DriveType { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? MinSpace { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? FreeSpace { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? ThresholdSpace { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? UsedSpace { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? Size { get; set; }
        [Column("FreeSpace%", TypeName = "decimal(38, 2)")]
        public decimal? FreeSpace1 { get; set; }
        [StringLength(128)]
        public string? VolumeName { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime? DataImportUtc { get; set; }
    }
}
