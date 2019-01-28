using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class removeCountryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Country_Country_id",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_Country_id",
                table: "School");

            migrationBuilder.RenameColumn(
                name: "Country_id",
                table: "School",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "School",
                newName: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_Country_id",
                table: "School",
                column: "Country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Country_Country_id",
                table: "School",
                column: "Country_id",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
