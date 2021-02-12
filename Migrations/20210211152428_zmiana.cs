using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetRentalCore.Migrations
{
    public partial class zmiana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 2, 11, 16, 24, 27, 879, DateTimeKind.Local).AddTicks(581));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 2, 9, 13, 21, 40, 284, DateTimeKind.Local).AddTicks(7313));
        }
    }
}
