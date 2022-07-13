using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig10_UpdateProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Displayed",
                table: "Tbl_Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Displayed",
                table: "Tbl_Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 15, 58, 673, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 15, 58, 676, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 5, 20, 20, 15, 58, 676, DateTimeKind.Local).AddTicks(8593));
        }
    }
}
