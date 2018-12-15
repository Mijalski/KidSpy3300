using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class assignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Marks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_AssignmentId",
                table: "Marks",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_SchoolClassId",
                table: "Assignment",
                column: "SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Assignment_AssignmentId",
                table: "Marks",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Assignment_AssignmentId",
                table: "Marks");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Marks_AssignmentId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Marks");
        }
    }
}
