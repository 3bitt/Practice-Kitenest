using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class ViewModelPartialViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Continentid",
                table: "Continent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continent_Continentid",
                table: "Continent",
                column: "Continentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Continent_Continent_Continentid",
                table: "Continent",
                column: "Continentid",
                principalTable: "Continent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Continent_Continent_Continentid",
                table: "Continent");

            migrationBuilder.DropIndex(
                name: "IX_Continent_Continentid",
                table: "Continent");

            migrationBuilder.DropColumn(
                name: "Continentid",
                table: "Continent");
        }
    }
}
