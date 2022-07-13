using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig12_UpdateProductEntityWithAddingICollectionFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 5, 25, 14, 40, 49, 8, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 5, 25, 14, 40, 49, 14, DateTimeKind.Local).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 5, 25, 14, 40, 49, 14, DateTimeKind.Local).AddTicks(6378));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
