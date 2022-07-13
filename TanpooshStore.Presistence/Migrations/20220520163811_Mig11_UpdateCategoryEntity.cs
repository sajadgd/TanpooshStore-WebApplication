using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig11_UpdateCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 21, 8, 11, 109, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 21, 8, 11, 113, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 21, 8, 11, 113, DateTimeKind.Local).AddTicks(1132));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 24, 8, 976, DateTimeKind.Local).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 24, 8, 979, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 24, 8, 979, DateTimeKind.Local).AddTicks(6906));
        }
    }
}
