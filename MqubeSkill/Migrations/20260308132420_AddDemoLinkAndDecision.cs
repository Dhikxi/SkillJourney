using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    public partial class AddDemoLinkAndDecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DemoLink",
                table: "DemoBookings",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentDecision",
                table: "DemoBookings",
                type: "longtext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemoLink",
                table: "DemoBookings");

            migrationBuilder.DropColumn(
                name: "StudentDecision",
                table: "DemoBookings");
        }
    }
}