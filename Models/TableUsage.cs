using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace dba.Models
{
    [Table("TableUsage", Schema = "dba")]
    public partial class TableUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        public string InstanceId { get; set; }
        [StringLength(128)]
        public string DbName { get; set; }
        [StringLength(128)]
        public string TableName { get; set; }
        [Precision(38,2)]
        public decimal UsedMB { get; set; }
        [Precision(38,2)]
        public decimal UnusedMB { get; set; }
        [Precision(38,2)]
        public decimal SizeMB { get; set; }
        public DateTime? DataImportUtc { get; set; }
    }
}