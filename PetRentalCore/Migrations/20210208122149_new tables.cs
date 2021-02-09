using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Accessorry_AccessorryId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Accessorry");

            migrationBuilder.DropTable(
                name: "AccessoryType");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_AccessorryId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AccessorryId",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "AccessoryId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalDate",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnDate",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Rentals_AccessoryId",
                table: "Rentals",
                column: "AccessoryId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Accessory_AccessoryId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "PetType");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_AccessoryId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AccessoryId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "AccessorryId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accessorry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryTypeId = table.Column<int>(type: "int", nullable: true),
                    PetTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessorry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessorry_AccessoryType_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_AccessorryId",
                table: "Rentals",
                column: "AccessorryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessorry_AccessoryTypeId",
                table: "Accessorry",
                column: "AccessoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Accessorry_AccessorryId",
                table: "Rentals",
                column: "AccessorryId",
                principalTable: "Accessorry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
