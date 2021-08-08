using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class AlotOfChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Members_MemberPurchasedId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Skills_SkillId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "LiveQuantity",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantityForUsage",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MembershipFeeCategories",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Members",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLeaving",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRegistration",
                table: "Members",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberPurchasedId",
                table: "Equipments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRope",
                table: "Equipments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Equipments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfReturn",
                table: "Borrows",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Members_MemberPurchasedId",
                table: "Equipments",
                column: "MemberPurchasedId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Skills_SkillId",
                table: "Members",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Members_MemberPurchasedId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Skills_SkillId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LiveQuantity",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "TotalQuantityForUsage",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MembershipFeeCategories");

            migrationBuilder.DropColumn(
                name: "DateOfLeaving",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DateOfRegistration",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsRope",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Members",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "MemberPurchasedId",
                table: "Equipments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfReturn",
                table: "Borrows",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Members_MemberPurchasedId",
                table: "Equipments",
                column: "MemberPurchasedId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Skills_SkillId",
                table: "Members",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
