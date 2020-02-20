using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreams.Web.Migrations
{
    public partial class AddUniqueCodeUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Units_Code",
                table: "Units",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_Code",
                table: "Units");
        }
    }
}
