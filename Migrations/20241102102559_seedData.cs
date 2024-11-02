using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreBasicDemo.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
				columns: ["CompanyCode", "CompanyCountry", "CompanyName", "CompanyTelephone"],
                values: new object[,]
                {
                    { "AC001", "EN", "Accenture", "01064858999" },
                    { "RMT", "CN", "Red Maple", "86866668888" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: ["Id", "CompanyCode", "Country_Code", "Description", "Name", "Sex", "StaffLevel"],
                values: new object[,]
                {
                    { 1, "AC001", "CN", "White Moon Light", "Xiaoyu", "female", 12 },
                    { 2, "AC001", "CN", "Software Engineer", "Henry", "male", 10 },
                    { 3, "RMT", "CN", "180+++++", "tony", "male", 10 },
                    { 4, "RMT", "CN", "Cute girl", "Henry", "female", 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "AC001");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "RMT");
        }
    }
}
