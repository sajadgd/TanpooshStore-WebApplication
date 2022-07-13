using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig8_UpdateUserAndUserInRoleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AdminSubMenu");

            migrationBuilder.DropTable(
                name: "Tbl_AdminMenu");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Tbl_UserInRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Tbl_UserInRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Tbl_UserInRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Tbl_UserInRole",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Tbl_UserInRole");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Tbl_UserInRole");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Tbl_UserInRole");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Tbl_UserInRole");

            migrationBuilder.CreateTable(
                name: "Tbl_AdminMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AdminMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AdminSubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Id = table.Column<int>(type: "int", nullable: false),
                    Sub_Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AdminSubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_AdminSubMenu_Tbl_AdminMenu_Menu_Id",
                        column: x => x.Menu_Id,
                        principalTable: "Tbl_AdminMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AdminSubMenu_Menu_Id",
                table: "Tbl_AdminSubMenu",
                column: "Menu_Id");
        }
    }
}
