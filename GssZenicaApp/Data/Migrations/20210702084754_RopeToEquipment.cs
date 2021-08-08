using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class RopeToEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Ropes_RopeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_RopeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "RopeId",
                table: "Equipments");

            migrationBuilder.AddColumn<bool>(
                name: "IsCut",
                table: "Equipments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Equipments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Thickness",
                table: "Equipments",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCut",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Thickness",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "RopeId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RopeId",
                table: "Equipments",
                column: "RopeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Ropes_RopeId",
                table: "Equipments",
                column: "RopeId",
                principalTable: "Ropes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
