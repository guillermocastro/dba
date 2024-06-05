using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("Restore", Schema = "dba")]
    public partial class Restore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RestoreId { get; set; }
        [StringLength(128)]
        [ForeignKey("Instance")]
        public string InstanceId { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? RestoreDate { get; set; }
        [StringLength(128)]
        public string? DbName { get; set; }
        [StringLength(128)]
        public string? UserName { get; set; }
        public int? BackupSetId { get; set; }
        [StringLength(1)]
        public string? RestoreTypeId { get; set; }
        public bool? Replace { get; set; }
        public bool? Recovery { get; set; }

        public virtual Instance Instance { get; set; } = null!;
    }
}
