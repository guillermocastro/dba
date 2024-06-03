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
            migrationBuilder.CreateTable(
                name: "Config",
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

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "VersionId", "ChangesBackup", "DailyBackup", "MonthlyBackup", "WeeklyBackup", "Yearly4Backup", "Yearly7Backup" },
                values: new object[] { "1.0.0", "\\\\vamwin\\shares\\Changes", "\\\\vamwin\\shares\\SQL Server Backups - Daily", "\\\\vamwin\\shares\\SQL Server Backups - Monthly", "\\\\vamwin\\shares\\SQL Server Backups - Weekly", "\\\\vamwin\\shares\\SQL Server Backups - Annual - 4year", "\\\\vamwin\\shares\\SQL Server Backups - Annual - 7 year" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
