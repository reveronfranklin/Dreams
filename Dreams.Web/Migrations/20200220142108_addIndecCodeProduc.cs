using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreams.Web.Migrations
{
    public partial class addIndecCodeProduc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Code",
                table: "Products");
        }
    }
}
