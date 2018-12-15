using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class assignments4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGraded",
                table: "Assignments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGraded",
                table: "Assignments");
        }
    }
}
