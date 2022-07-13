using Microsoft.EntityFrameworkCore.Migrations;

namespace TanpooshStore.Presistence.Migrations
{
    public partial class Mig5_UpdateUserEntityAndOtherActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tbl_Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tbl_Users");
        }
    }
}
