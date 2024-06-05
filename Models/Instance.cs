using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dba.Models
{
    [Table("Instance", Schema = "dba")]
    public partial class Instance
    {
        public Instance()
        {
            DeviceId = "";
            Dbs = new HashSet<Db>();
            DbFiles = new HashSet<DbFile>();
            DbBackups = new HashSet<DbBackup>();
            Restores = new HashSet<Restore>();
            DbTables = new HashSet<DbTable>();
            //TableUsages = new HashSet<TableUsage>();
            //Configurations = new HashSet<Configuration>();
            //Dbjobs = new HashSet<Dbjob>();
            //DuplicatedIndices = new HashSet<DuplicatedIndex>();
            //InstanceCounters = new HashSet<InstanceCounter>();
            //MissingIndices = new HashSet<MissingIndex>();
            //PerfMons = new HashSet<PerfMon>();
            //TmpDbbackups = new HashSet<TmpDbbackup>();
            //UnusedIndices = new HashSet<UnusedIndex>();
        }

        [Key]
        [StringLength(128)]
        public string InstanceId { get; set; } = null!;
        [StringLength(255)]
        public string? Hostname { get; set; }
        [StringLength(5)]
        public string? Port { get; set; }
        [ForeignKey("Device")]
        [StringLength(24)]
        public string DeviceId { get; set; } = null!;
        [StringLength(300)]
        public string? Version { get; set; }
        [StringLength(128)]
        public string? Edition { get; set; }
        [StringLength(128)]
        public string? Level { get; set; }
        [StringLength(128)]
        public string? ProductUpdateLevel { get; set; }
        [StringLength(128)]
        public string? ProductUpdateReference { get; set; }
        [StringLength(128)]
        public string? ResourceLastUpdateDateTime { get; set; }
        [StringLength(128)]
        public string? ProductVersion { get; set; }
        [StringLength(256)]
        public string? DbeAccount { get; set; }
        [StringLength(256)]
        public string? AgentAccount { get; set; }
        [StringLength(128)]
        public string? InstanceDefaultDataPath { get; set; }
        [StringLength(128)]
        public string? InstanceDefaultLogPath { get; set; }
        [StringLength(256)]
        public string? BackupDirectory { get; set; }
        [StringLength(6)]
        public string? ServerState { get; set; }
        [StringLength(128)]
        public string? IsSingleUser { get; set; }
        [StringLength(128)]
        public string? Collation { get; set; }
        public bool? RemoteBackup { get; set; }
        [StringLength(12)]
        public string? Environment { get; set; }
        //[StringLength(1024)]
        //public string? Description { get; set; }
        [StringLength(128)]
        public string? Owner { get; set; }
        [StringLength(128)]
        public string? Listener { get; set; }
        [StringLength(128)]
        public string? Comments { get; set; }
        [StringLength(64)]
        public string? LicenseKey { get; set; }
        public int? cpu_count { get; set; }
        public int? VirtualProcessors { get; set; }
        [StringLength(128)]
        public string? Use { get; set; }
        public byte[]? ConnectionString { get; set; }
        [StringLength(260)]
        public string? Certificate { get; set; }
        public DateTime? DataImportUtc { get; set; }

        public virtual Device Device { get; set;}
        public virtual ICollection<Db> Dbs { get; set; }
        public virtual ICollection<DbFile> DbFiles { get; set; }
        public virtual ICollection<DbBackup> DbBackups { get; set; }
        public virtual ICollection<Restore> Restores { get; set; }
        public virtual ICollection<DbTable> DbTables { get; set; }

        //public virtual ICollection<TableUsage> TableUsages { get; set; }
        //public virtual ICollection<Configuration> Configurations { get; set; }
        //public virtual ICollection<Dbjob> Dbjobs { get; set; }
        //public virtual ICollection<DuplicatedIndex> DuplicatedIndices { get; set; }
        //public virtual ICollection<InstanceCounter> InstanceCounters { get; set; }
        //public virtual ICollection<MissingIndex> MissingIndices { get; set; }
        //public virtual ICollection<PerfMon1> PerfMon1s { get; set; }
        //public virtual ICollection<Restore> Restores { get; set; }
        //public virtual ICollection<TmpDbbackup> TmpDbbackups { get; set; }
        //public virtual ICollection<UnusedIndex> UnusedIndices { get; set; }
    }
}
