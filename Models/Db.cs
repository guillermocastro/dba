using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("DB", Schema = "dba")]
    public partial class Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Instance")]
        [StringLength(128)]
        public string InstanceId { get; set; } = null!;
        [StringLength(128)]
        public string DbName { get; set; } = null!;
        public bool? IsUserDb { get; set; }
        [StringLength(20)]
        public string? DbState { get; set; }
        [StringLength(20)]
        public string? DbUserAccess { get; set; }
        [StringLength(20)]
        public string? DbRecovery { get; set; }
        [StringLength(128)]
        public string? Dbcollation { get; set; }
        public int? DbCompatibility { get; set; }
        public DateTime? DbCreation { get; set; }
        [StringLength(10)]
        public string? DbUse { get; set; }
        public bool? PersonalData { get; set; }
        public bool? IsReplica { get; set; }
        public DateTime? LastDbcheck { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReIndex { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastShrink { get; set; }
        public DateTime? DataImportUtc { get; set; }

        public virtual Instance Instance { get; set; } = null!;
    }
}
