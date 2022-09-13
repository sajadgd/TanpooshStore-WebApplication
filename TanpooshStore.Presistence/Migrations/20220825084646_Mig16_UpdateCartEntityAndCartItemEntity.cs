using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig16_UpdateCartEntityAndCartItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Tbl_CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Tbl_Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 25, 13, 16, 45, 815, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 25, 13, 16, 45, 819, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 8, 25, 13, 16, 45, 819, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CartItem_CartId",
                table: "Tbl_CartItem",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CartItem_Tbl_Cart_CartId",
                table: "Tbl_CartItem",
                column: "CartId",
                principalTable: "Tbl_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CartItem_Tbl_Cart_CartId",
                table: "Tbl_CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_CartItem_CartId",
                table: "Tbl_CartItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Tbl_CartItem");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Tbl_Cart");

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 22, 13, 48, 4, 985, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 22, 13, 48, 4, 989, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 8, 22, 13, 48, 4, 989, DateTimeKind.Local).AddTicks(5481));
        }
    }
}
