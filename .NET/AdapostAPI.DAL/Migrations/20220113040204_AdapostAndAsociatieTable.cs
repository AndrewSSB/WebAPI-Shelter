using Microsoft.EntityFrameworkCore.Migrations;

namespace AdapostAPI.DAL.Migrations
{
    public partial class AdapostAndAsociatieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Adoptantis",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Asociaties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asociaties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdapostAsociaties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdapostId = table.Column<int>(type: "int", nullable: false),
                    AsociatieId = table.Column<int>(type: "int", nullable: false),
                    SumaDonata = table.Column<decimal>(type: "decimal(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdapostAsociaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdapostAsociaties_Adaposts_AdapostId",
                        column: x => x.AdapostId,
                        principalTable: "Adaposts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdapostAsociaties_Asociaties_AsociatieId",
                        column: x => x.AsociatieId,
                        principalTable: "Asociaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdapostAsociaties_AdapostId",
                table: "AdapostAsociaties",
                column: "AdapostId");

            migrationBuilder.CreateIndex(
                name: "IX_AdapostAsociaties_AsociatieId",
                table: "AdapostAsociaties",
                column: "AsociatieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdapostAsociaties");

            migrationBuilder.DropTable(
                name: "Asociaties");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Adoptantis",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
