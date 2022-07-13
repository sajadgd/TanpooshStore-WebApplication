using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class AddCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Tbl_Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Tbl_Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Tbl_Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Tbl_Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Category_Tbl_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Category_ParentCategoryId",
                table: "Tbl_Category",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Tbl_Role");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Tbl_Role");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Tbl_Role");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Tbl_Role");
        }
    }
}
