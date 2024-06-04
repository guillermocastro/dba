using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorDBM.Models
{
    [Table("Device", Schema = "dbm")]
    public partial class Device
    {
        public Device()
        {
            //Instances = new HashSet<Instance>();
        }

        [Key]
        [StringLength(24)]
        public string DeviceId { get; set; } = null!;
        [Column("OS")]
        [StringLength(128)]
        public string? Os { get; set; }
        [StringLength(128)]
        public string? Manufacturer { get; set; }
        [StringLength(128)]
        public string? Model { get; set; }
        [StringLength(32)]
        public string? Category { get; set; }
        [StringLength(64)]
        public string? Version { get; set; }
        [Column("OSBuild")]
        [StringLength(64)]
        public string? Osbuild { get; set; }
        [StringLength(64)]
        public string? SerialNo { get; set; }
        [Column("RAM")]
        [StringLength(64)]
        public string? Ram { get; set; }
        [Column("CPU")]
        [StringLength(128)]
        public string? Cpu { get; set; }
        public int? Cores { get; set; }
        [Column("MAC")]
        [StringLength(20)]
        public string? Mac { get; set; }
        [Column("IPAddress")]
        [StringLength(32)]
        public string? Ipaddress { get; set; }
        [StringLength(64)]
        public string? SiteName { get; set; }
        [StringLength(64)]
        public string? Location { get; set; }
        [StringLength(32)]
        public string? Antivirus { get; set; }
        [StringLength(128)]
        public string? Department { get; set; }
        [Column("InAD")]
        public bool? InAd { get; set; }
        public bool? WoL { get; set; }
        [StringLength(64)]
        public string? SerialNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastDetection { get; set; }
        public string? Description { get; set; }
        public string? Attributes { get; set; }
        [StringLength(20)]
        public string? PlatformId { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime? DataImportUtc { get; set; }

        //[InverseProperty(nameof(Instance.Device))]
        //public virtual ICollection<Instance> Instances { get; set; }
    }
}
