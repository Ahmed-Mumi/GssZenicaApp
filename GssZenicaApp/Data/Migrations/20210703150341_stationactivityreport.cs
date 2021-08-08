using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class stationactivityreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationActivityId",
                table: "Reports",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
