using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dba.Migrations
{
    /// <inheritdoc />
    public partial class m01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dba");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                schema: "dba",
                columns: table => new
                {
                    VersionId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DailyBackup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    WeeklyBackup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MonthlyBackup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Yearly4Backup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Yearly7Backup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ChangesBackup = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.VersionId);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                schema: "dba",
                table: "Config",
                columns: new[] { "VersionId", "ChangesBackup", "DailyBackup", "MonthlyBackup", "WeeklyBackup", "Yearly4Backup", "Yearly7Backup" },
                values: new object[] { "1.0.0", "\\\\vamwin\\shares\\Changes", "\\\\vamwin\\shares\\SQL Server Backups - Daily", "\\\\vamwin\\shares\\SQL Server Backups - Monthly", "\\\\vamwin\\shares\\SQL Server Backups - Weekly", "\\\\vamwin\\shares\\SQL Server Backups - Annual - 4year", "\\\\vamwin\\shares\\SQL Server Backups - Annual - 7 year" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Config",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "Disk",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "Instance",
                schema: "dba");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "dba");
        }
    }
}
