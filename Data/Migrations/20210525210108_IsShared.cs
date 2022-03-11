using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing4Everyone2._0.Data.Migrations
{
    public partial class IsShared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "Route",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "Route");
        }
    }
}
