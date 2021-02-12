using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class rows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "Name", "RegistrationDate", "Surname" },
                values: new object[] { 1, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", new DateTime(2021, 2, 9, 13, 21, 40, 284, DateTimeKind.Local).AddTicks(7313), "Jablonska" });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "PetTypeName" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Parrot" },
                    { 4, "Mouse" },
                    { 5, "Rat" },
                    { 6, "Hamster" },
                    { 7, "Horse" },
                    { 8, "Pig" }
                });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeName",
                value: 0);

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeName" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryName", "OneDayRentalPrice", "PetTypeId", "SizeId" },
                values: new object[] { 1, "Kurtka Randig", 10.00m, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeName",
                value: 3);
        }
    }
}
