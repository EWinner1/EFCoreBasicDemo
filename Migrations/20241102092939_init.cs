using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBasicDemo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyTelephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCountry = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyCode", x => x.CompanyCode);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StaffLevel = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country_Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Company_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Company",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Cascade);
                });

			migrationBuilder.CreateIndex(
                name: "IX_Staff_CompanyCode",
                table: "Staff",
                column: "CompanyCode");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Company");
        }

		//private void InsertData(MigrationBuilder migrationBuilder)
		//{
		//	migrationBuilder.InsertData(
		//		table: "Staff",
		//		columns: ["Name", "Sex", "StaffLevel", "Description", "CompanyCode", "Country_Code"],
		//		values: new object[,]
		//		{
		//	{"Xiaoyu", "female", 12, "White Moon Light", "AC001", "CN" },
		//	{"Henry", "male", 10, "Software Engineer", "AC001", "CN" },
		//	{"tony", "male", 10, "180+++++", "RMT", "CN" },
		//	{"Henry", "female", 11, "Cute girl", "RMT", "CN" }
		//		});

		//	migrationBuilder.InsertData(
		//		table: "Company",
		//		columns: ["CompanyCode", "CompanyName", "CompanyTelephone", "CompanyCountry"],
		//		values: new object[,]
		//		{
		//	{ "AC001", "Accenture", "EN", "01064858999" },
		//	{ "RMT", "Red Maple", "CN", "86866668888" }
		//		});
		//}
	}
}
