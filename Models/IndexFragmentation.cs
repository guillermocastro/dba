using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("IndexFragmentation", Schema = "dba")]
    public partial class IndexFragmentation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        public string InstanceId { get; set; }
        [StringLength(128)]
        public string Db { get; set; }
        [StringLength(128)]
        public string DbTable { get; set; }
        [StringLength(128)]
        public string DbIndex { get; set; }
        [Precision(18,2)]
        public decimal Fragmentation { get; set; }
        public int? page_count { get; set; }
        public DateTime? DataImportUtc { get; set; }
    }
}