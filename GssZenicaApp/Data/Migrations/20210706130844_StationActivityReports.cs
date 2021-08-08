using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class StationActivityReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_StationActivities_StationActivityId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_StationActivityId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StationActivityId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "StationActivities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationActivities_ReportId",
                table: "StationActivities",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StationActivities_Reports_ReportId",
                table: "StationActivities",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationActivities_Reports_ReportId",
                table: "StationActivities");

            migrationBuilder.DropIndex(
                name: "IX_StationActivities_ReportId",
                table: "StationActivities");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "StationActivities");

            migrationBuilder.AddColumn<int>(
                name: "StationActivityId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StationActivityId",
                table: "Reports",
                column: "StationActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_StationActivities_StationActivityId",
                table: "Reports",
                column: "StationActivityId",
                principalTable: "StationActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
