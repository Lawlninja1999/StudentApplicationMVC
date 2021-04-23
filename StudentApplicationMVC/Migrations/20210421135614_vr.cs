using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationMVC.Migrations
{
    public partial class vr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "UnitDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeachersID",
                table: "UnitDetails",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "Grades",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentDetailsID",
                table: "Grades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeachersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TeacherNumber = table.Column<string>(nullable: true),
                    TeacherPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeachersID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitDetails_TeachersID",
                table: "UnitDetails",
                column: "TeachersID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentDetailsID",
                table: "Grades",
                column: "StudentDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentDetails_StudentDetailsID",
                table: "Grades",
                column: "StudentDetailsID",
                principalTable: "StudentDetails",
                principalColumn: "StudentDetailsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails",
                column: "TeachersID",
                principalTable: "Teachers",
                principalColumn: "TeachersID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentDetails_StudentDetailsID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_UnitDetails_TeachersID",
                table: "UnitDetails");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentDetailsID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "UnitDetails");

            migrationBuilder.DropColumn(
                name: "TeachersID",
                table: "UnitDetails");

            migrationBuilder.DropColumn(
                name: "StudentDetailsID",
                table: "Grades");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }
    }
}
