using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class newaccesory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryName", "OneDayRentalPrice", "PetTypeId", "SizeId" },
                values: new object[] { 1, "Kurtka Randig", 10.00m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryName", "OneDayRentalPrice", "PetTypeId", "SizeId" },
                values: new object[] { 2, "Kurtka Dotted", 9.00m, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
