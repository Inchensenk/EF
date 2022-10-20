using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreStart.Migrations
{
    public partial class RenameIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Users",
                newName: "Id");
        }
    }
}
