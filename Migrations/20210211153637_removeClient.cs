using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class removeClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryName", "OneDayRentalPrice", "PetTypeId", "SizeId" },
                values: new object[] { 1, "Kurtka Randig", 10.00m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "Name", "RegistrationDate", "Surname" },
                values: new object[] { 1, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", new DateTime(2021, 2, 11, 16, 27, 42, 661, DateTimeKind.Local).AddTicks(6983), "Jablonska" });
        }
    }
}
