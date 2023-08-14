using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "Province", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Tech City", "Tech Solution", "123523234", "M3N3C6", "ON", "123 Tech St" },
                    { 2, "Vivi City", "Vivi Data", "4645645688", "M5W3C6", "ON", "999 Vivi St" },
                    { 3, "Lala Land", "Tundra Club", "310284872", "E3N3C6", "AL", "878 Main St" },
                    { 4, "Wasa City", "Wasabi Solution", "103765537", "D5O2V5", "MB", "235 Wasabi St" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
