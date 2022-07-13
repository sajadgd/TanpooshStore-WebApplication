using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig2_AddAdminMenuAndAdminSubMenuEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Sub_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Menu_Id = table.Column<int>(type: "int", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AdminSubMenu");

            migrationBuilder.DropTable(
                name: "Tbl_AdminMenu");
        }
    }
}
