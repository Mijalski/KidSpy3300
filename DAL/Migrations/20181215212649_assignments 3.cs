using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class assignments3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_SchoolClasses_SchoolClassId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Assignment_AssignmentId",
                table: "Marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "Assignments");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_SchoolClassId",
                table: "Assignments",
                newName: "IX_Assignments_SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_SchoolClasses_SchoolClassId",
                table: "Assignments",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Assignments_AssignmentId",
                table: "Marks",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_SchoolClasses_SchoolClassId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Assignments_AssignmentId",
                table: "Marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_SchoolClassId",
                table: "Assignment",
                newName: "IX_Assignment_SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_SchoolClasses_SchoolClassId",
                table: "Assignment",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Assignment_AssignmentId",
                table: "Marks",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
