using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class ActivityStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StationActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfActivity = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: false),
                    StationActivityId = table.Column<int>(nullable: true),
                    ActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMembers_StationActivities_StationActivityId",
                        column: x => x.StationActivityId,
                        principalTable: "StationActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMembers_MemberId",
                table: "ActivityMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMembers_StationActivityId",
                table: "ActivityMembers",
                column: "StationActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityMembers");

            migrationBuilder.DropTable(
                name: "StationActivities");
        }
    }
}
