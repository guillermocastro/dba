using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dba.Models
{
    [Table("Device", Schema = "dba")]
    public partial class Device
    {
        public Device()
        {
            Instances = new HashSet<Instance>();
            Disks = new HashSet<Disk>();
        }

        [Key]
        [StringLength(24)]
        public string DeviceId { get; set; } = null!;
        [StringLength(64)]
        public string? Ram { get; set; }
        [StringLength(128)]
        public string? Cpu { get; set; }
        public int? Cores { get; set; }
        public DateTime? DataImportUtc { get; set; }

        public virtual ICollection<Instance> Instances { get; set; }
        public virtual ICollection<Disk> Disks { get; set; }
    }
}
