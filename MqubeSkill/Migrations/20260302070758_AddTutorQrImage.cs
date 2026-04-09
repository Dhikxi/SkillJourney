using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    /// <inheritdoc />
    public partial class AddTutorQrImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrImagePath",
                table: "Tutors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrImagePath",
                table: "Tutors");
        }
    }
}
