using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestGroupId",
                table: "DemoBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestGroupId",
                table: "DemoBookings");
        }
    }
}
