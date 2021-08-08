using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class BorrowChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Equipments_EquipmentId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_EquipmentId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentCategoryId",
                table: "Borrows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_EquipmentCategoryId",
                table: "Borrows",
                column: "EquipmentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_EquipmentCategories_EquipmentCategoryId",
                table: "Borrows",
                column: "EquipmentCategoryId",
                principalTable: "EquipmentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_EquipmentCategories_EquipmentCategoryId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_EquipmentCategoryId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "EquipmentCategoryId",
                table: "Borrows");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_EquipmentId",
                table: "Borrows",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Equipments_EquipmentId",
                table: "Borrows",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
