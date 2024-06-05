using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("DbBackup", Schema = "dba")]
    public partial class DbBackup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Instance")]
        [StringLength(128)]
        public string InstanceId { get; set; } = null!;
        [StringLength(128)]
        public string? DbName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BackupStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BackupEnd { get; set; }
        [StringLength(15)]
        public string? TimeTaken { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? BackupType { get; set; }
        public bool? IsPasswordProtected { get; set; }
        public bool? IsCompressed { get; set; }
        public bool IsEncrypted { get; set; }
        [Precision(18,2)]
        public decimal? CompressedSizeKb { get; set; }
        [Precision(18,2)]
        public decimal? BackupSizeKb { get; set; }
        [StringLength(260)]
        public string? BackupFile { get; set; }
        //[StringLength(255)]
        //public string? Description { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string? DeviceType { get; set; }
        [StringLength(25)]
        public decimal? FirstLsn { get; set; }
        [StringLength(25)]
        public decimal? LastLsn { get; set; }
        [StringLength(25)]
        public decimal? CheckpointLsn { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime? DataImportUtc { get; set; }

        public virtual Instance Instance { get; set; } = null!;
    }
}
