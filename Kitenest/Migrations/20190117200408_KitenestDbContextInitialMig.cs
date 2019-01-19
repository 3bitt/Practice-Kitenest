using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitenest.Migrations
{
    public partial class KitenestDbContextInitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTime",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    openHour = table.Column<DateTime>(nullable: false),
                    closeHour = table.Column<DateTime>(nullable: false),
                    workingFrom = table.Column<DateTime>(nullable: false),
                    workingTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTime", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Continentid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Continent_Continentid",
                        column: x => x.Continentid,
                        principalTable: "Continent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Mobile = table.Column<int>(nullable: false),
                    Continent_id = table.Column<int>(nullable: false),
                    Country_id = table.Column<int>(nullable: false),
                    City_id = table.Column<int>(nullable: false),
                    School_Time_id = table.Column<int>(nullable: false),
                    SchoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                    table.ForeignKey(
                        name: "FK_School_City_City_id",
                        column: x => x.City_id,
                        principalTable: "City",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_Continent_Continent_id",
                        column: x => x.Continent_id,
                        principalTable: "Continent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_Country_Country_id",
                        column: x => x.Country_id,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_School_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_SchoolTime_School_Time_id",
                        column: x => x.School_Time_id,
                        principalTable: "SchoolTime",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Continentid",
                table: "Country",
                column: "Continentid");

            migrationBuilder.CreateIndex(
                name: "IX_School_City_id",
                table: "School",
                column: "City_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_Continent_id",
                table: "School",
                column: "Continent_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_Country_id",
                table: "School",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_SchoolId",
                table: "School",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_School_School_Time_id",
                table: "School",
                column: "School_Time_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "SchoolTime");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continent");
        }
    }
}
