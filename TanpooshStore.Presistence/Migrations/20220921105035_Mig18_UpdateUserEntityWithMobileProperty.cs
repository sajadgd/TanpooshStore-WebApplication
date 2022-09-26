using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig18_UpdateUserEntityWithMobileProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Tbl_Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 9, 21, 15, 20, 34, 695, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 9, 21, 15, 20, 34, 700, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 9, 21, 15, 20, 34, 700, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Mobile",
                table: "Tbl_Users",
                column: "Mobile",
                unique: true,
                filter: "[Mobile] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tbl_Users_Mobile",
                table: "Tbl_Users");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Tbl_Users");

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 9, 17, 13, 48, 14, 203, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 9, 17, 13, 48, 14, 206, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 9, 17, 13, 48, 14, 206, DateTimeKind.Local).AddTicks(6348));
        }
    }
}
