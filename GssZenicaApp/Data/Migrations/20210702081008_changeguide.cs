using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class changeguide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GuideCategories");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "GuideCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "GuideCategories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GuideCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
