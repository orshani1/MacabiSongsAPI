using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacabiSongsAPI.Migrations
{
    public partial class FixUSER_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_Id",
                table: "Users",
                newName: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Users",
                newName: "_Id");
        }
    }
}
