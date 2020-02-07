using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon2020Team4.Data.Migrations
{
    public partial class AddModuleDateTimeStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateTimeStart",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Modules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Modules");
        }
    }
}
