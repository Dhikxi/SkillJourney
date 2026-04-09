using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MqubeSkill.Migrations
{
    public partial class AddSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // REMOVE THIS (column not in DB)
            // migrationBuilder.DropColumn(
            //     name: "QRCodePath",
            //     table: "Tutors");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Subjects",
                table: "Tutors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Qualification",
                table: "Tutors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Availability",
                table: "Tutors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            // REMOVE THESE (already exist in DB)
            // migrationBuilder.AddColumn<string>(
            //     name: "Address",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "ContactNo",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "DegreePath",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "IdentityProofPath",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "ResumePath",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "SkypeId",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "WhatsAppNo",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "WorkingHours",
            //     table: "Tutors",
            //     type: "longtext",
            //     nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PreferredTime",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ParentName",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "GradeLevel",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Board",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4");

            // REMOVE THESE ALSO (already exist)
            // migrationBuilder.AddColumn<string>(
            //     name: "Address",
            //     table: "Students",
            //     type: "longtext",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "ContactNo",
            //     table: "Students",
            //     type: "longtext",
            //     nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}