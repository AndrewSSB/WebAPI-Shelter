using Microsoft.EntityFrameworkCore.Migrations;

namespace AdapostAPI.DAL.Migrations
{
    public partial class ChangedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptantis_Animals_AnimalId",
                table: "Adoptantis");

            migrationBuilder.DropIndex(
                name: "IX_Adoptantis_AnimalId",
                table: "Adoptantis");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Adoptantis");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AdoptantiId",
                table: "Animals",
                column: "AdoptantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Adoptantis_AdoptantiId",
                table: "Animals",
                column: "AdoptantiId",
                principalTable: "Adoptantis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Adoptantis_AdoptantiId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AdoptantiId",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Adoptantis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptantis_AnimalId",
                table: "Adoptantis",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptantis_Animals_AnimalId",
                table: "Adoptantis",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
