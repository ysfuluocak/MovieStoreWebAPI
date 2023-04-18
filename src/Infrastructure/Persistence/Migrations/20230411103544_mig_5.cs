using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Users_UserId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Users_UserId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_UserId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_UserId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Directors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_UserId",
                table: "Directors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_UserId",
                table: "Actors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Users_UserId",
                table: "Actors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Users_UserId",
                table: "Directors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
