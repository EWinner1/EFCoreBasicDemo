using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBasicDemo.Migrations
{
    /// <inheritdoc />
    public partial class updateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "AC001",
                columns: new[] { "CompanyCountry", "CompanyTelephone" },
                values: new object[] { "EN", "01064858999" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "RMT",
                columns: new[] { "CompanyCountry", "CompanyTelephone" },
                values: new object[] { "CN", "86866668888" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "AC001",
                columns: new[] { "CompanyCountry", "CompanyTelephone" },
                values: new object[] { "01064858999", "EN" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyCode",
                keyValue: "RMT",
                columns: new[] { "CompanyCountry", "CompanyTelephone" },
                values: new object[] { "86866668888", "CN" });
        }
    }
}
