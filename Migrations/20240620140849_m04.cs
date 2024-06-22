using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dba.Migrations
{
    /// <inheritdoc />
    public partial class m04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackupFile",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BackupSet = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Directory = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SizeMB = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastWriteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DataImportUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackupFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuplicatedIndex",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Db = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbTable = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Columns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    include_columns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DBIndex = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuplicatedIndex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndexFragmentation",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Db = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbTable = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbIndex = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Fragmentation = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    page_count = table.Column<int>(type: "int", nullable: true),
                    DataImportUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexFragmentation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableUsage",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UsedMB = table.Column<decimal>(type: "decimal(38,2)", precision: 38, scale: 2, nullable: false),
                    UnusedMB = table.Column<decimal>(type: "decimal(38,2)", precision: 38, scale: 2, nullable: false),
                    SizeMB = table.Column<decimal>(type: "decimal(38,2)", precision: 38, scale: 2, nullable: false),
                    DataImportUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableUsage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnusedIndex",
                schema: "dba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DBTable = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DBIndex = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    user_seeks = table.Column<int>(type: "int", nullable: false),
                    user_scans = table.Column<int>(type: "int", nullable: false),
                    user_updates = table.Column<int>(type: "int", nullable: false),
                    DataImportUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnusedIndex", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackupFile",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "DuplicatedIndex",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "IndexFragmentation",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "TableUsage",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "UnusedIndex",
                schema: "dba");
        }
    }
}
