using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dba.Models
{
    [Table("Instance", Schema = "dba")]
    public partial class Instance
    {
        //public Instance()
        //{
            //Configurations = new HashSet<Configuration>();
            //Dbbackups = new HashSet<Dbbackup>();
            //Dbfiles = new HashSet<Dbfile>();
            //Dbjobs = new HashSet<Dbjob>();
            //Dbrestores = new HashSet<Dbrestore>();
            //Dbs = new HashSet<Db>();
            //Dbtables = new HashSet<Dbtable>();
            //DuplicatedIndices = new HashSet<DuplicatedIndex>();
            //InstanceCounters = new HashSet<InstanceCounter>();
            //MissingIndices = new HashSet<MissingIndex>();
            //PerfMon1s = new HashSet<PerfMon1>();
            //Restores = new HashSet<Restore>();
            //TableUsage1s = new HashSet<TableUsage1>();
            //TmpDbbackups = new HashSet<TmpDbbackup>();
            //UnusedIndices = new HashSet<UnusedIndex>();
        //}

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
        public DateTime? DataImportUtc { get; set; }

        public virtual Device Device { get; set;}

        //[InverseProperty(nameof(Configuration.Instance))]
        //public virtual ICollection<Configuration> Configurations { get; set; }
        //[InverseProperty(nameof(Dbbackup.Instance))]
        //public virtual ICollection<Dbbackup> Dbbackups { get; set; }
        //[InverseProperty(nameof(Dbfile.Instance))]
        //public virtual ICollection<Dbfile> Dbfiles { get; set; }
        //[InverseProperty(nameof(Dbjob.Instance))]
        //public virtual ICollection<Dbjob> Dbjobs { get; set; }
        //[InverseProperty(nameof(Dbrestore.Instance))]
        //public virtual ICollection<Dbrestore> Dbrestores { get; set; }
        //[InverseProperty(nameof(Db.Instance))]
        //public virtual ICollection<Db> Dbs { get; set; }
        //[InverseProperty(nameof(Dbtable.Instance))]
        //public virtual ICollection<Dbtable> Dbtables { get; set; }
        //[InverseProperty(nameof(DuplicatedIndex.Instance))]
        //public virtual ICollection<DuplicatedIndex> DuplicatedIndices { get; set; }
        //[InverseProperty(nameof(InstanceCounter.Instance))]
        //public virtual ICollection<InstanceCounter> InstanceCounters { get; set; }
        //[InverseProperty(nameof(MissingIndex.Instance))]
        //public virtual ICollection<MissingIndex> MissingIndices { get; set; }
        //[InverseProperty(nameof(PerfMon1.Instance))]
        //public virtual ICollection<PerfMon1> PerfMon1s { get; set; }
        //[InverseProperty(nameof(Restore.Instance))]
        //public virtual ICollection<Restore> Restores { get; set; }
        //[InverseProperty(nameof(TableUsage1.Instance))]
        //public virtual ICollection<TableUsage1> TableUsage1s { get; set; }
        //[InverseProperty(nameof(TmpDbbackup.Instance))]
        //public virtual ICollection<TmpDbbackup> TmpDbbackups { get; set; }
        //[InverseProperty(nameof(UnusedIndex.Instance))]
        //public virtual ICollection<UnusedIndex> UnusedIndices { get; set; }
    }
}
