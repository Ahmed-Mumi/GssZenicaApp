using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class changedstationactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityMembers_StationActivities_StationActivityId",
                table: "ActivityMembers");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "ActivityMembers");

            migrationBuilder.AlterColumn<int>(
                name: "StationActivityId",
                table: "ActivityMembers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityMembers_StationActivities_StationActivityId",
                table: "ActivityMembers",
                column: "StationActivityId",
                principalTable: "StationActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityMembers_StationActivities_StationActivityId",
                table: "ActivityMembers");

            migrationBuilder.AlterColumn<int>(
                name: "StationActivityId",
                table: "ActivityMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "ActivityMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityMembers_StationActivities_StationActivityId",
                table: "ActivityMembers",
                column: "StationActivityId",
                principalTable: "StationActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
