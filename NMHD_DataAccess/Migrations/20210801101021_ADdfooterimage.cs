using Microsoft.EntityFrameworkCore.Migrations;

namespace NMHD_DataAccess.Migrations
{
    public partial class ADdfooterimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterImageUrl",
                table: "StoreConfigs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterImageUrl",
                table: "StoreConfigs");
        }
    }
}
