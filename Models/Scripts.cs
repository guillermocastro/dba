using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("Scripts", Schema = "dba")]
    public partial class Scripts{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        public string ScriptName { get; set; }
        [StringLength(20)]
        public string ScriptVersion { get; set; }
        [StringLength(20)]
        public string ScriptType { get; set; } //StoredProcedure, Job, SQL PS
        public string Code { get; set; }
    }
}