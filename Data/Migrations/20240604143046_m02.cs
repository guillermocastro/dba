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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Config",
                schema: "dba",
                newName: "Config");
        }
    }
}
