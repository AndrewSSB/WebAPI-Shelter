using Microsoft.EntityFrameworkCore.Migrations;

namespace AdapostAPI.DAL.Migrations
{
    public partial class VizitatorAndAdapostChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdapostVizitator_Adaposts_AdapostId",
                table: "AdapostVizitator");

            migrationBuilder.DropForeignKey(
                name: "FK_AdapostVizitator_Vizitator_VizitatorId",
                table: "AdapostVizitator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vizitator",
                table: "Vizitator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdapostVizitator",
                table: "AdapostVizitator");

            migrationBuilder.RenameTable(
                name: "Vizitator",
                newName: "Vizitators");

            migrationBuilder.RenameTable(
                name: "AdapostVizitator",
                newName: "AdapostVizitators");

            migrationBuilder.RenameIndex(
                name: "IX_AdapostVizitator_VizitatorId",
                table: "AdapostVizitators",
                newName: "IX_AdapostVizitators_VizitatorId");

            migrationBuilder.RenameIndex(
                name: "IX_AdapostVizitator_AdapostId",
                table: "AdapostVizitators",
                newName: "IX_AdapostVizitators_AdapostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vizitators",
                table: "Vizitators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdapostVizitators",
                table: "AdapostVizitators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdapostVizitators_Adaposts_AdapostId",
                table: "AdapostVizitators",
                column: "AdapostId",
                principalTable: "Adaposts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdapostVizitators_Vizitators_VizitatorId",
                table: "AdapostVizitators",
                column: "VizitatorId",
                principalTable: "Vizitators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdapostVizitators_Adaposts_AdapostId",
                table: "AdapostVizitators");

            migrationBuilder.DropForeignKey(
                name: "FK_AdapostVizitators_Vizitators_VizitatorId",
                table: "AdapostVizitators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vizitators",
                table: "Vizitators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdapostVizitators",
                table: "AdapostVizitators");

            migrationBuilder.RenameTable(
                name: "Vizitators",
                newName: "Vizitator");

            migrationBuilder.RenameTable(
                name: "AdapostVizitators",
                newName: "AdapostVizitator");

            migrationBuilder.RenameIndex(
                name: "IX_AdapostVizitators_VizitatorId",
                table: "AdapostVizitator",
                newName: "IX_AdapostVizitator_VizitatorId");

            migrationBuilder.RenameIndex(
                name: "IX_AdapostVizitators_AdapostId",
                table: "AdapostVizitator",
                newName: "IX_AdapostVizitator_AdapostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vizitator",
                table: "Vizitator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdapostVizitator",
                table: "AdapostVizitator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdapostVizitator_Adaposts_AdapostId",
                table: "AdapostVizitator",
                column: "AdapostId",
                principalTable: "Adaposts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdapostVizitator_Vizitator_VizitatorId",
                table: "AdapostVizitator",
                column: "VizitatorId",
                principalTable: "Vizitator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
