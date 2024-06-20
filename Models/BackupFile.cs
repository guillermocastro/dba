using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dba.Models
{
    [Table("BackupFile", Schema = "dba")]
    public partial class BackupFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(128)]
        public string InstanceId { get; set; }
        [StringLength(128)]
        public string DbName { get; set; }
        [StringLength(128)]
        public string BackupSet { get; set; }
        [StringLength(256)]
        public string Directory { get; set; }
        [StringLength(128)]
        public string Filename { get; set; }
        [StringLength(128)]
        public string SizeMB { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastWriteDate { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        public DateTime? DataImportUtc { get; set; }
    }
}