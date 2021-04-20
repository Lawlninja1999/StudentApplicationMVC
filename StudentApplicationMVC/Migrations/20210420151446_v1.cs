using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationMVC.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StudentPhoto = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    StudentNumber = table.Column<int>(nullable: false),
                    AccessLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "UnitDetails",
                columns: table => new
                {
                    UnitDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTitle = table.Column<string>(nullable: true),
                    UnitCode = table.Column<string>(nullable: true),
                    Campus = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDetails", x => x.UnitDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    StudentGradesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(nullable: true),
                    UnitDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.StudentGradesID);
                    table.ForeignKey(
                        name: "FK_Grades_UnitDetails_UnitDetailsID",
                        column: x => x.UnitDetailsID,
                        principalTable: "UnitDetails",
                        principalColumn: "UnitDetailsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UnitDetailsID",
                table: "Grades",
                column: "UnitDetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "UnitDetails");
        }
    }
}
