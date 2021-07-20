using Microsoft.EntityFrameworkCore.Migrations;

namespace NMHD_DataAccess.Migrations
{
    public partial class addbannerprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "BlogPosts");
        }
    }
}
