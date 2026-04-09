using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectIdToDemoBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "DemoBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DemoBookings_StudentId",
                table: "DemoBookings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DemoBookings_TutorId",
                table: "DemoBookings",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DemoBookings_Students_StudentId",
                table: "DemoBookings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DemoBookings_Tutors_TutorId",
                table: "DemoBookings",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "TutorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemoBookings_Students_StudentId",
                table: "DemoBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_DemoBookings_Tutors_TutorId",
                table: "DemoBookings");

            migrationBuilder.DropIndex(
                name: "IX_DemoBookings_StudentId",
                table: "DemoBookings");

            migrationBuilder.DropIndex(
                name: "IX_DemoBookings_TutorId",
                table: "DemoBookings");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "DemoBookings");
        }
    }
}
