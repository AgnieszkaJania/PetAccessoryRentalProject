using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class fixaccessorytablerealtiontorental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessorryRental");

            migrationBuilder.AddColumn<int>(
                name: "AccessorryId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_AccessorryId",
                table: "Rentals",
                column: "AccessorryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Accessorry_AccessorryId",
                table: "Rentals",
                column: "AccessorryId",
                principalTable: "Accessorry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Accessorry_AccessorryId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_AccessorryId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AccessorryId",
                table: "Rentals");

            migrationBuilder.CreateTable(
                name: "AccessorryRental",
                columns: table => new
                {
                    AccessorriesId = table.Column<int>(type: "int", nullable: false),
                    RentalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessorryRental", x => new { x.AccessorriesId, x.RentalsId });
                    table.ForeignKey(
                        name: "FK_AccessorryRental_Accessorry_AccessorriesId",
                        column: x => x.AccessorriesId,
                        principalTable: "Accessorry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessorryRental_Rentals_RentalsId",
                        column: x => x.RentalsId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessorryRental_RentalsId",
                table: "AccessorryRental",
                column: "RentalsId");
        }
    }
}
