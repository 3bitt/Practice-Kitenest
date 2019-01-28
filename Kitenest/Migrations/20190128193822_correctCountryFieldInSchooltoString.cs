using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class correctCountryFieldInSchooltoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "School",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "School",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
