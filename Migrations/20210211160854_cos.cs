using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class cos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetTypes",
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
                keyValue: 1);

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

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "PetTypeName" },
                values: new object[,]
                {
                    { 11, "Dog" },
                    { 12, "Cat" },
                    { 13, "Parrot" },
                    { 14, "Mouse" },
                    { 15, "Rat" },
                    { 16, "Hamster" },
                    { 17, "Horse" },
                    { 18, "Pig" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeName" },
                values: new object[,]
                {
                    { 10, 0 },
                    { 11, 1 },
                    { 12, 2 },
                    { 13, 3 },
                    { 14, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 14);

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

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeName" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });
        }
    }
}
