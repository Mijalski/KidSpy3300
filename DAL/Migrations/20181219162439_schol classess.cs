using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class scholclassess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "Name", "TeacherAccountId" },
                values: new object[,]
                {
                    { 100, "1A", null },
                    { 101, "1B", null },
                    { 102, "1C", null },
                    { 103, "1D", null },
                    { 104, "2A", null },
                    { 105, "2B", null },
                    { 106, "2C", null },
                    { 107, "3A", null },
                    { 108, "3B", null },
                    { 109, "3C", null },
                    { 110, "3S", null },
                    { 111, "4A", null },
                    { 112, "4B", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 112);
        }
    }
}
