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
        [Column("DBName")]
        [StringLength(128)]
        public string DbName { get; set; } = null!;
        [Column("IsUserDB")]
        public bool? IsUserDb { get; set; }
        [Column("DBState")]
        [StringLength(20)]
        public string? DbState { get; set; }
        [Column("DBUserAccess")]
        [StringLength(20)]
        public string? DbUserAccess { get; set; }
        [Column("DBRecovery")]
        [StringLength(20)]
        public string? DbRecovery { get; set; }
        [Column("DBCollation")]
        [StringLength(128)]
        public string? Dbcollation { get; set; }
        [Column("DBCompatibility")]
        public int? DbCompatibility { get; set; }
        [Column("DBCreation", TypeName = "datetime")]
        public DateTime? DbCreation { get; set; }
        [Column("DBUse")]
        [StringLength(10)]
        public string? DbUse { get; set; }
        public bool? PersonalData { get; set; }
        public bool? IsReplica { get; set; }
        [Column("LastDBCheck", TypeName = "datetime")]
        public DateTime? LastDbcheck { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReIndex { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastShrink { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime? DataImportUtc { get; set; }

        public virtual Instance Instance { get; set; } = null!;
    }
}
