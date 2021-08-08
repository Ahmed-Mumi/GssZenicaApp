using Microsoft.EntityFrameworkCore.Migrations;

namespace GssZenicaApp.Data.Migrations
{
    public partial class presencecounteradde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresenceCounter",
                table: "Members",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresenceCounter",
                table: "Members");
        }
    }
}
