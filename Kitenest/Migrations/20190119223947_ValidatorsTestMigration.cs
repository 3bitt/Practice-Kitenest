using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class ValidatorsTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_City_City_id",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Country_Country_id",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SchoolTime_School_Time_id",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_City_id",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_Country_id",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_School_Time_id",
                table: "School");

            migrationBuilder.DropColumn(
                name: "City_id",
                table: "School");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "School");

            migrationBuilder.DropColumn(
                name: "School_Time_id",
                table: "School");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cityid",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "School",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "School",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_Cityid",
                table: "School",
                column: "Cityid");

            migrationBuilder.CreateIndex(
                name: "IX_School_CountryId",
                table: "School",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_City_Cityid",
                table: "School",
                column: "Cityid",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Country_CountryId",
                table: "School",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_City_Cityid",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Country_CountryId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_Cityid",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_CountryId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "City",
                table: "School");

            migrationBuilder.DropColumn(
                name: "Cityid",
                table: "School");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "School");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "School");

            migrationBuilder.AddColumn<int>(
                name: "City_id",
                table: "School",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Country_id",
                table: "School",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "School_Time_id",
                table: "School",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_School_City_id",
                table: "School",
                column: "City_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_Country_id",
                table: "School",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_School_Time_id",
                table: "School",
                column: "School_Time_id");

            migrationBuilder.AddForeignKey(
                name: "FK_School_City_City_id",
                table: "School",
                column: "City_id",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Country_Country_id",
                table: "School",
                column: "Country_id",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_SchoolTime_School_Time_id",
                table: "School",
                column: "School_Time_id",
                principalTable: "SchoolTime",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
