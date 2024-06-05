using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("DbTable", Schema = "dba")]
    public partial class DbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [StringLength(128)]
        
        public string InstanceId { get; set; } = null!;
        [StringLength(128)]
        public string DbName { get; set; } = null!;
        [StringLength(128)]
        public string? TableName { get; set; }
        [Precision(18,2)]
        public decimal? Rows { get; set; }
        [Precision(18,2)]
        public decimal? Reserved { get; set; }
        [Precision(18,2)]
        public decimal? Data { get; set; }
        [Precision(18,2)]
        public decimal? IndexSize { get; set; }
        [Precision(18,2)]
        public decimal? Unused { get; set; }
        [Column("DataImportUTC", TypeName = "datetime")]
        public DateTime DataImportUtc { get; set; }

        public virtual Instance Instance { get; set; } = null!;
    }
}
