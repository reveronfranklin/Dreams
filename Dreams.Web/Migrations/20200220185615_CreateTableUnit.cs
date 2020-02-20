using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreams.Web.Migrations
{
    public partial class CreateTableUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_UnitEntity_UnitId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitEntity",
                table: "UnitEntity");

            migrationBuilder.RenameTable(
                name: "UnitEntity",
                newName: "Units");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "UnitEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitEntity",
                table: "UnitEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_UnitEntity_UnitId",
                table: "Ingredients",
                column: "UnitId",
                principalTable: "UnitEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
