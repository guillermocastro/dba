using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dba.Migrations
{
    /// <inheritdoc />
    public partial class m03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dba",
                table: "Config",
                keyColumn: "VersionId",
                keyValue: "1.0.0",
                column: "License",
                value: "473EF1B7-0514-4038-999F-8CD547AC0050");

            migrationBuilder.InsertData(
                schema: "dba",
                table: "SqlServer",
                columns: new[] { "SqlServerId", "SqlServerVersion" },
                values: new object[,]
                {
                    { "12.0", "Sql Server 2014" },
                    { "13.0", "Sql Server 2016" },
                    { "14.0", "Sql Server 2017" },
                    { "15.0", "Sql Server 2019" },
                    { "16.0", "Sql Server 2022" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dba",
                table: "SqlServer",
                keyColumn: "SqlServerId",
                keyValue: "12.0");

            migrationBuilder.DeleteData(
                schema: "dba",
                table: "SqlServer",
                keyColumn: "SqlServerId",
                keyValue: "13.0");

            migrationBuilder.DeleteData(
                schema: "dba",
                table: "SqlServer",
                keyColumn: "SqlServerId",
                keyValue: "14.0");

            migrationBuilder.DeleteData(
                schema: "dba",
                table: "SqlServer",
                keyColumn: "SqlServerId",
                keyValue: "15.0");

            migrationBuilder.DeleteData(
                schema: "dba",
                table: "SqlServer",
                keyColumn: "SqlServerId",
                keyValue: "16.0");

            migrationBuilder.UpdateData(
                schema: "dba",
                table: "Config",
                keyColumn: "VersionId",
                keyValue: "1.0.0",
                column: "License",
                value: null);
        }
    }
}
