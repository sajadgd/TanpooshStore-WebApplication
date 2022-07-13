using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig9_AddProductsAndProductImagesAndProductFeaturesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Invertory = table.Column<int>(type: "int", nullable: false),
                    Displayed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductFeatures_Tbl_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductImages_Tbl_Products_ProductId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductFeatures_ProductId",
                table: "Tbl_ProductFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductImages_ProductId",
                table: "Tbl_ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_CategoryId",
                table: "Tbl_Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ProductFeatures");

            migrationBuilder.DropTable(
                name: "Tbl_ProductImages");

            migrationBuilder.DropTable(
                name: "Tbl_Products");

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 16, 19, 2, 26, 489, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 4, 16, 19, 2, 26, 495, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 4, 16, 19, 2, 26, 495, DateTimeKind.Local).AddTicks(961));
        }
    }
}
