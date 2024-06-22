using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("DbFile", Schema = "dba")]
    public partial class DbFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        [ForeignKey("Instance")]
        public string InstanceId { get; set; } = null!;
        [StringLength(128)]
        public string DbName { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string FileName { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string? FileType { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? PhysicalDisk { get; set; }
        [Precision(18,2)]
        public decimal? MaxSizeMb { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? Growth { get; set; }
        [Precision(18,2)]
        public decimal? FileSizeMb { get; set; }
        [Precision(18,2)]
        public decimal? FreeSpaceMb { get; set; }
        [Precision(18,2)]
        public decimal? FreeSpace { get; set; }
        public DateTime? DataImportUtc { get; set; }


        public virtual Instance Instance { get; set; } = null!;
    }
}
