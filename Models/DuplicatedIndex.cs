using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace dba.Models
{
    [Table("DuplicatedIndex", Schema = "dba")]
    public partial class DuplicatedIndex
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
        public string Columns { get; set; }
        public string include_columns { get; set; }
        [StringLength(128)]
        public string DBIndex { get; set; }
    }
}