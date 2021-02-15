using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OneDayRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PetTypeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessories_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "Name", "RegistrationDate", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", new DateTime(2021, 2, 15, 19, 15, 59, 257, DateTimeKind.Local).AddTicks(2066), "Jablonska" },
                    { 2, new DateTime(1996, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agnieszka", new DateTime(2021, 2, 15, 19, 15, 59, 260, DateTimeKind.Local).AddTicks(9679), "Nowak" },
                    { 3, new DateTime(2000, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agnieszka", new DateTime(2021, 2, 15, 19, 15, 59, 260, DateTimeKind.Local).AddTicks(9806), "Babacka" },
                    { 4, new DateTime(1986, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mateusz", new DateTime(2021, 2, 15, 19, 15, 59, 260, DateTimeKind.Local).AddTicks(9839), "Dadacki" },
                    { 5, new DateTime(1999, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcin", new DateTime(2021, 2, 15, 19, 15, 59, 260, DateTimeKind.Local).AddTicks(9867), "Abacki" },
                    { 6, new DateTime(1978, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ewa", new DateTime(2021, 2, 15, 19, 15, 59, 260, DateTimeKind.Local).AddTicks(9915), "Jakas" }
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "PetTypeName" },
                values: new object[,]
                {
                    { 8, "Pig" },
                    { 7, "Horse" },
                    { 6, "Hamster" },
                    { 5, "Rat" },
                    { 4, "Mouse" },
                    { 3, "Parrot" },
                    { 2, "Cat" },
                    { 1, "Dog" }
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

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryName", "OneDayRentalPrice", "PetTypeId", "SizeId" },
                values: new object[,]
                {
                    { 1, "Kurtka Randig", 10.00m, 1, 1 },
                    { 27, "Kurtka smiley", 20.00m, 7, 3 },
                    { 31, "Kurtka grey", 17.00m, 7, 3 },
                    { 35, "Kurtka warmy", 10.00m, 8, 3 },
                    { 4, "Kurtka Randig", 10.00m, 1, 4 },
                    { 9, "Kurtka Dotted", 9.00m, 2, 4 },
                    { 11, "Szelki Stripped", 3.00m, 1, 4 },
                    { 23, "Sweterek w Kwaiatki", 4.00m, 6, 3 },
                    { 13, "Szelki Stripped", 3.00m, 2, 4 },
                    { 32, "Kurtka grey", 17.00m, 7, 4 },
                    { 5, "Kurtka Randig", 10.00m, 1, 5 },
                    { 10, "Kurtka Dotted", 9.00m, 2, 5 },
                    { 12, "Szelki Stripped", 3.00m, 1, 5 },
                    { 14, "Szelki Stripped", 3.00m, 2, 5 },
                    { 24, "Sweterek w Kwaiatki", 4.00m, 6, 5 },
                    { 28, "Kurtka smiley", 20.00m, 7, 4 },
                    { 17, "Szelki Malutkie", 5.00m, 4, 3 },
                    { 8, "Kurtka Dotted", 9.00m, 2, 3 },
                    { 3, "Kurtka Randig", 10.00m, 1, 3 },
                    { 6, "Kurtka Dotted", 9.00m, 2, 1 },
                    { 15, "Szelki Malutkie", 5.00m, 4, 1 },
                    { 18, "Szelki Malutkie", 5.00m, 5, 1 },
                    { 19, "Szelki Malutkie", 5.00m, 5, 1 },
                    { 20, "Szelki Malutkie", 5.00m, 5, 1 },
                    { 21, "Sweterek w Kwaiatki", 4.00m, 6, 1 },
                    { 25, "Kurtka smiley", 20.00m, 7, 1 },
                    { 33, "Szelki piggy", 13.00m, 8, 1 },
                    { 2, "Kurtka Randig", 10.00m, 1, 2 },
                    { 7, "Kurtka Dotted", 9.00m, 2, 2 },
                    { 16, "Szelki Malutkie", 5.00m, 4, 2 },
                    { 22, "Sweterek w Kwaiatki", 4.00m, 6, 2 },
                    { 26, "Kurtka smiley", 20.00m, 7, 2 },
                    { 30, "Kurtka grey", 17.00m, 7, 2 },
                    { 34, "Szelki piggy", 13.00m, 8, 2 },
                    { 29, "Kurtka smiley", 20.00m, 7, 5 },
                    { 36, "Kurtka warmy", 10.00m, 8, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_PetTypeId",
                table: "Accessories",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_SizeId",
                table: "Accessories",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_AccessoryId",
                table: "Rentals",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
