using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class SkillsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MedicalCourse",
                table: "Skills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rescurer",
                table: "Skills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SummerCourse",
                table: "Skills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WinterCourse",
                table: "Skills",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalCourse",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Rescurer",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SummerCourse",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "WinterCourse",
                table: "Skills");
        }
    }
}
