using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationMVC.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addNewUnits");

            migrationBuilder.CreateTable(
                name: "addUnitDetails",
                columns: table => new
                {
                    AddUnitDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTitle = table.Column<string>(nullable: true),
                    UnitCode = table.Column<string>(nullable: true),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false),
                    UnitOutline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addUnitDetails", x => x.AddUnitDetailsID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addUnitDetails");

            migrationBuilder.CreateTable(
                name: "addNewUnits",
                columns: table => new
                {
                    AddNewUnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assignment1 = table.Column<int>(type: "int", nullable: false),
                    Assignment2 = table.Column<int>(type: "int", nullable: false),
                    Exam = table.Column<int>(type: "int", nullable: false),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOutline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addNewUnits", x => x.AddNewUnitID);
                });
        }
    }
}
