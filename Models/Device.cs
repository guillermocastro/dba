using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("Device", Schema = "dba")]
    public partial class Device
    {
        public Device()
        {
            //Instances = new HashSet<Instance>();
        }

        [Key]
        [StringLength(24)]
        public string DeviceId { get; set; } = null!;
        [Column("RAM")]
        [StringLength(64)]
        public string? Ram { get; set; }
        [Column("CPU")]
        [StringLength(128)]
        public string? Cpu { get; set; }
        public int? Cores { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime? DataImportUtc { get; set; }

        //[InverseProperty(nameof(Instance.Device))]
        //public virtual ICollection<Instance> Instances { get; set; }
    }
}
