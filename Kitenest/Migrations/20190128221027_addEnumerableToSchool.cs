using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class addEnumerableToSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "School",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_SchoolId",
                table: "School",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_School_SchoolId",
                table: "School",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_School_SchoolId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_SchoolId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "School");
        }
    }
}
