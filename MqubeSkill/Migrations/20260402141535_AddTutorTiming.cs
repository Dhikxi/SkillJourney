using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    /// <inheritdoc />
    public partial class AddTutorTiming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "AvailableEndTime",
                table: "Tutors",
                type: "time(6)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AvailableStartTime",
                table: "Tutors",
                type: "time(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableEndTime",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "AvailableStartTime",
                table: "Tutors");
        }
    }
}
