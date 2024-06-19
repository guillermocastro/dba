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
            migrationBuilder.AddColumn<string>(
                name: "AdminState",
                schema: "dba",
                table: "Instance",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EncryptedBackup",
                schema: "dba",
                table: "Instance",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "License",
                schema: "dba",
                table: "Config",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dba",
                table: "Config",
                keyColumn: "VersionId",
                keyValue: "1.0.0",
                column: "License",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminState",
                schema: "dba",
                table: "Instance");

            migrationBuilder.DropColumn(
                name: "EncryptedBackup",
                schema: "dba",
                table: "Instance");

            migrationBuilder.DropColumn(
                name: "License",
                schema: "dba",
                table: "Config");
        }
    }
}
