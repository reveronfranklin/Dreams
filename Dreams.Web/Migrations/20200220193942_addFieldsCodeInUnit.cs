using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreams.Web.Migrations
{
    public partial class addFieldsCodeInUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Units",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Ingredients",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Code",
                table: "Ingredients",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Code",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Ingredients");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Units",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
