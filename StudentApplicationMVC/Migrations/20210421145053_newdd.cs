using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationMVC.Migrations
{
    public partial class newdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "UnitDetails");

            migrationBuilder.AlterColumn<int>(
                name: "TeachersID",
                table: "UnitDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails",
                column: "TeachersID",
                principalTable: "Teachers",
                principalColumn: "TeachersID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails");

            migrationBuilder.AlterColumn<int>(
                name: "TeachersID",
                table: "UnitDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "UnitDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitDetails_Teachers_TeachersID",
                table: "UnitDetails",
                column: "TeachersID",
                principalTable: "Teachers",
                principalColumn: "TeachersID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
