using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dba.Models
{
    [Table("UnusedIndex", Schema = "dba")]
    public partial class UnusedIndex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        public string InstanceId { get; set; }
        [StringLength(128)]
        public string DbName { get; set; }
        [StringLength(128)]
        public string DBTable { get; set; }
        [StringLength(128)]
        public string DBIndex { get; set; }
        public int user_seeks { get; set; }
        public int user_scans { get; set; }
        public int user_updates { get; set; }
        public DateTime? DataImportUtc { get; set; }
    }
}