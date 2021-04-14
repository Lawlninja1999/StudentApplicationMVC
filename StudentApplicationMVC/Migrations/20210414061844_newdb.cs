using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationMVC.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addNewUnits",
                columns: table => new
                {
                    AddNewUnitID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_addNewUnits", x => x.AddNewUnitID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addNewUnits");
        }
    }
}
