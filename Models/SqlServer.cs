﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
// https://endoflife.date/mssqlserver
namespace dba.Models
{
    [Table("SqlServer", Schema = "dba")]
    public partial class SqlServer
    {
        public SqlServer()
        {
            SqlPatchs = new HashSet<SqlPatch>();
        }

        [Key]
        [StringLength(4)]
        public string SqlServerId { get; set; } = null!;
        [StringLength(64)]
        public string SqlServerVersion { get; set; } = null!;
        private DateTime? EndActiveSupport { get; set; }
        private DateTime? EndSecuritySupport { get; set; }
        private DateTime? ExtendedSecurityUpdates { get; set; }

        public virtual ICollection<SqlPatch> SqlPatchs { get; set; }
    }
}
