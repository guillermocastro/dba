using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("Disk", Schema = "dba")]
    public partial class Disk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Device")]
        [StringLength(24)]
        public string DeviceId { get; set; } = null!;
        [StringLength(10)]
        public string? Drive { get; set; }
        [StringLength(18)]
        public string? DriveType { get; set; }
        [Precision(18,2)]
        public decimal? FreeSpace { get; set; }
        [Precision(18,2)]
        public decimal? UsedSpace { get; set; }
        [Precision(18,2)]
        public decimal? Size { get; set; }
        [StringLength(128)]
        public string? VolumeName { get; set; }
        public DateTime? DataImportUtc { get; set; }

        public virtual Device Device { get; set; } = null!;
    }
}
