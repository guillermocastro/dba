using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dba.Migrations
{
    /// <inheritdoc />
    public partial class m02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dba");

            migrationBuilder.RenameTable(
                name: "Config",
                newName: "Config",
                newSchema: "dba");

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "dba",
                columns: table => new
                {
                    DeviceId = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Disk",
                schema: "dba",
                columns: table => new
                {
                    DiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Drive = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DriveType = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    MinSpace = table.Column<decimal>(type: "decimal(38,2)", nullable: true),
                    FreeSpace = table.Column<decimal>(type: "decimal(38,2)", nullable: true),
                    ThresholdSpace = table.Column<decimal>(type: "decimal(38,2)", nullable: true),
                    UsedSpace = table.Column<decimal>(type: "decimal(38,2)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(38,2)", nullable: true),
                    FreeSpace0 = table.Column<decimal>(name: "FreeSpace%", type: "decimal(38,2)", nullable: true),
                    VolumeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disk", x => x.DiskId);
                });

            migrationBuilder.CreateTable(
                name: "Instance",
                schema: "dba",
                columns: table => new
                {
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Port = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Edition = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductUpdateLevel = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductUpdateReference = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ResourceLastUpdateDateTime = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DbeAccount = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AgentAccount = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InstanceDefaultDataPath = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    InstanceDefaultLogPath = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BackupDirectory = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ServerState = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    IsSingleUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Collation = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    RemoteBackup = table.Column<bool>(type: "bit", nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Listener = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LicenseKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    cpu_count = table.Column<int>(type: "int", nullable: true),
                    VirtualProcessors = table.Column<int>(type: "int", nullable: true),
                    Use = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ConnectionString = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataImportUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instance", x => x.InstanceId);
                    table.ForeignKey(
                        name: "FK_Instance_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dba",
                        principalTable: "Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instance_DeviceId",
                schema: "dba",
                table: "Instance",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disk",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "Instance",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "dba");

            migrationBuilder.RenameTable(
                name: "Config",
                schema: "dba",
                newName: "Config");
        }
    }
}
