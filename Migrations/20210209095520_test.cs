using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Accessory_AccessoryId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Client_ClientId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PetType");

            migrationBuilder.DropTable(
                name: "Size");

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

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "SizeName" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_PetTypeId",
                table: "Accessories",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_SizeId",
                table: "Accessories",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Accessories_AccessoryId",
                table: "Rentals",
                column: "AccessoryId",
                principalTable: "Accessories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Clients_ClientId",
                table: "Rentals",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Accessories_AccessoryId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Clients_ClientId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OneDayRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PetTypeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_PetType_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_PetTypeId",
                table: "Accessory",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_SizeId",
                table: "Accessory",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Accessory_AccessoryId",
                table: "Rentals",
                column: "AccessoryId",
                principalTable: "Accessory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Client_ClientId",
                table: "Rentals",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
