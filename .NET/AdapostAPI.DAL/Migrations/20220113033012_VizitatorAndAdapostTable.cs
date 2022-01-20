using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdapostAPI.DAL.Migrations
{
    public partial class VizitatorAndAdapostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vizitator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizitator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdapostVizitator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdapostId = table.Column<int>(type: "int", nullable: false),
                    VizitatorId = table.Column<int>(type: "int", nullable: false),
                    DataVizitei = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdapostVizitator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdapostVizitator_Adaposts_AdapostId",
                        column: x => x.AdapostId,
                        principalTable: "Adaposts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdapostVizitator_Vizitator_VizitatorId",
                        column: x => x.VizitatorId,
                        principalTable: "Vizitator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdapostVizitator_AdapostId",
                table: "AdapostVizitator",
                column: "AdapostId");

            migrationBuilder.CreateIndex(
                name: "IX_AdapostVizitator_VizitatorId",
                table: "AdapostVizitator",
                column: "VizitatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdapostVizitator");

            migrationBuilder.DropTable(
                name: "Vizitator");
        }
    }
}
