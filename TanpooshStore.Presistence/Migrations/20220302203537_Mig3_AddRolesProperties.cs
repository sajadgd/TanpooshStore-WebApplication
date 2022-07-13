using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig3_AddRolesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tbl_Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Tbl_Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Operator" });

            migrationBuilder.InsertData(
                table: "Tbl_Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
