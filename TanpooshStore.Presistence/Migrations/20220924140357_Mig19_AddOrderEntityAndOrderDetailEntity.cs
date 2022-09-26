using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig19_AddOrderEntityAndOrderDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedTime",
                table: "Tbl_Cart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Tbl_Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequestPayId = table.Column<int>(type: "int", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_RequestPay_RequestPayId",
                        column: x => x.RequestPayId,
                        principalTable: "Tbl_RequestPay",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_OrderDetail_Tbl_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Tbl_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_OrderDetail_Tbl_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 17, 33, 56, 602, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 17, 33, 56, 606, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 17, 33, 56, 606, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_RequestPayId",
                table: "Tbl_Order",
                column: "RequestPayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_UserId",
                table: "Tbl_Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OrderDetail_OrderId",
                table: "Tbl_OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OrderDetail_ProductId",
                table: "Tbl_OrderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_OrderDetail");

            migrationBuilder.DropTable(
                name: "Tbl_Order");

            migrationBuilder.DropColumn(
                name: "FinishedTime",
                table: "Tbl_Cart");

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
        }
    }
}
