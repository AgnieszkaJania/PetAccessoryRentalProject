using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class newacc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 1);
        }
    }
}
