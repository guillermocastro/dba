using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
// https://support.microsoft.com/en-us/help/3133750/sql-server-2012-sp3-build-versions
// https://support.microsoft.com/en-us/topic/kb2936603-sql-server-2014-build-versions-6f75da99-d86f-53fa-23ce-3d2b4825eccb
// https://learn.microsoft.com/en-US/troubleshoot/sql/releases/sqlserver-2016/build-versions
// https://learn.microsoft.com/en-US/troubleshoot/sql/releases/sqlserver-2017/build-versions
// https://learn.microsoft.com/en-US/troubleshoot/sql/releases/sqlserver-2019/build-versions

namespace dba.Models
{
    [Table("SqlPatch", Schema = "dba")]
    public partial class SqlPatch
    {
        [Key]
        [StringLength(32)]
        public string SqlpatchId { get; set; } = null!;
        [StringLength(4)]
        [Column("SQLServerId")]
        public string SqlserverId { get; set; } = null!;
        [Column("CUN")]
        [StringLength(32)]
        public string Cun { get; set; } = null!;
        [Column("SQLPatchDate", TypeName = "datetime")]
        public DateTime? SqlpatchDate { get; set; }
        [Column("CE")]
        [StringLength(13)]
        [Unicode(false)]
        public string PatchStatus { get; set; } = null!;
    }
}
