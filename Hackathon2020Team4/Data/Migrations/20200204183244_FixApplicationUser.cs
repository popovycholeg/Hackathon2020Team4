using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon2020Team4.Data.Migrations
{
    public partial class FixApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users1_UserID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users1_UserID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Users1");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Instructors");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Instructors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstMidName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserID",
                table: "Students",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ApplicationUserID",
                table: "Instructors",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ApplicationUserID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "FirstMidName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users1", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users1_UserID",
                table: "Instructors",
                column: "UserID",
                principalTable: "Users1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users1_UserID",
                table: "Students",
                column: "UserID",
                principalTable: "Users1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
