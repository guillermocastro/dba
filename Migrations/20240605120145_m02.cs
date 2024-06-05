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
            migrationBuilder.DropColumn(
                name: "FreeSpace%",
                schema: "dba",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "MinSpace",
                schema: "dba",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "ThresholdSpace",
                schema: "dba",
                table: "Disk");

            migrationBuilder.RenameColumn(
                name: "DiskId",
                schema: "dba",
                table: "Disk",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                schema: "dba",
                table: "Instance",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UsedSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                schema: "dba",
                table: "Disk",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                schema: "dba",
                table: "Disk",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "DB",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DBName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsUserDB = table.Column<bool>(type: "bit", nullable: true),
                    DBState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DBUserAccess = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DBRecovery = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DBCollation = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DBCompatibility = table.Column<int>(type: "int", nullable: true),
                    DBCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DBUse = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PersonalData = table.Column<bool>(type: "bit", nullable: true),
                    IsReplica = table.Column<bool>(type: "bit", nullable: true),
                    LastDBCheck = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastReIndex = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastShrink = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DB_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "dba",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbBackup",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BackupStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    BackupEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeTaken = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BackupType = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    IsPasswordProtected = table.Column<bool>(type: "bit", nullable: true),
                    IsCompressed = table.Column<bool>(type: "bit", nullable: true),
                    IsEncrypted = table.Column<bool>(type: "bit", nullable: false),
                    CompressedSizeKb = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BackupSizeKb = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BackupFile = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    DeviceType = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    FirstLsn = table.Column<decimal>(type: "decimal(18,2)", maxLength: 25, nullable: true),
                    LastLsn = table.Column<decimal>(type: "decimal(18,2)", maxLength: 25, nullable: true),
                    CheckpointLsn = table.Column<decimal>(type: "decimal(18,2)", maxLength: 25, nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbBackup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbBackup_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "dba",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbFile",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FileName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    FileType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PhysicalDisk = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    MaxSizeMb = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Growth = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    FileSizeMb = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    FreeSpaceMb = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    FreeSpace = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbFile_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "dba",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbTable",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Rows = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Reserved = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Data = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IndexSize = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Unused = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DataImportUTC = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTable_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "dba",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restore",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestoreId = table.Column<int>(type: "int", nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RestoreDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BackupSetId = table.Column<int>(type: "int", nullable: true),
                    RestoreTypeId = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Replace = table.Column<bool>(type: "bit", nullable: true),
                    Recovery = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restore_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "dba",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SqlServer",
                schema: "dba",
                columns: table => new
                {
                    SqlServerId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    SqlServerVersion = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlServer", x => x.SqlServerId);
                });

            migrationBuilder.CreateTable(
                name: "SqlPatch",
                schema: "dba",
                columns: table => new
                {
                    SqlpatchId = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SQLServerId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CUN = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SQLPatchDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CE = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlPatch", x => x.SqlpatchId);
                    table.ForeignKey(
                        name: "FK_SqlPatch_SqlServer_SQLServerId",
                        column: x => x.SQLServerId,
                        principalSchema: "dba",
                        principalTable: "SqlServer",
                        principalColumn: "SqlServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disk_DeviceId",
                schema: "dba",
                table: "Disk",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_InstanceId",
                schema: "dba",
                table: "DB",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbBackup_InstanceId",
                schema: "dba",
                table: "DbBackup",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFile_InstanceId",
                schema: "dba",
                table: "DbFile",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTable_InstanceId",
                schema: "dba",
                table: "DbTable",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Restore_InstanceId",
                schema: "dba",
                table: "Restore",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SqlPatch_SQLServerId",
                schema: "dba",
                table: "SqlPatch",
                column: "SQLServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Device_DeviceId",
                schema: "dba",
                table: "Disk",
                column: "DeviceId",
                principalSchema: "dba",
                principalTable: "Device",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Device_DeviceId",
                schema: "dba",
                table: "Disk");

            migrationBuilder.DropTable(
                name: "DB",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "DbBackup",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "DbFile",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "DbTable",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "Restore",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "SqlPatch",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "SqlServer",
                schema: "dba");

            migrationBuilder.DropIndex(
                name: "IX_Disk_DeviceId",
                schema: "dba",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "Certificate",
                schema: "dba",
                table: "Instance");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dba",
                table: "Disk",
                newName: "DiskId");

            migrationBuilder.AlterColumn<decimal>(
                name: "UsedSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                schema: "dba",
                table: "Disk",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldMaxLength: 24);

            migrationBuilder.AddColumn<decimal>(
                name: "FreeSpace%",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThresholdSpace",
                schema: "dba",
                table: "Disk",
                type: "decimal(38,2)",
                nullable: true);
        }
    }
}
