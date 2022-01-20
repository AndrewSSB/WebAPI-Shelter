using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdapostAPI.DAL.Migrations
{
    public partial class SomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judet = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adaposts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adaposts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adaposts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInmatriculare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Greutate = table.Column<decimal>(type: "decimal(4,2)", maxLength: 30, nullable: false),
                    Inaltime = table.Column<decimal>(type: "decimal(4,2)", maxLength: 30, nullable: false),
                    varsta = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AdapostId = table.Column<int>(type: "int", nullable: false),
                    AdoptantiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Adaposts_AdapostId",
                        column: x => x.AdapostId,
                        principalTable: "Adaposts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employeers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataAngajarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Salariu = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    AdapostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employeers_Adaposts_AdapostId",
                        column: x => x.AdapostId,
                        principalTable: "Adaposts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptantis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptantis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptantis_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adaposts_LocationId",
                table: "Adaposts",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptantis_AnimalId",
                table: "Adoptantis",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AdapostId",
                table: "Animals",
                column: "AdapostId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeers_AdapostId",
                table: "Employeers",
                column: "AdapostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptantis");

            migrationBuilder.DropTable(
                name: "Employeers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Adaposts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
