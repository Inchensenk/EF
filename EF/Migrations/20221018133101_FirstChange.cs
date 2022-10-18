using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreStart.Migrations
{
    public partial class FirstChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //авто прямая миграция 
            /*
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
            */

            //кастомная прямая миграция(добавление коллонки PhoneNumber в таблицу Users)
            migrationBuilder.AddColumn<string>(nameof(User.PhoneNumber)/*имя добавляемой коллонки*/,nameof( MyDbContext.Users)/*имя таблицы*/, "nvarchar(max)"/*тип*/, nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //авто обратная миграция
            /*
            migrationBuilder.DropTable(
                name: "Users");
            */

            //кастомная обратная миграция (Удаление колонки PhoneNumber из таблицы Users)
            migrationBuilder.DropColumn(nameof(User.PhoneNumber)/*имя добавляемой коллонки*/, nameof(MyDbContext.Users)/*имя таблицы*/);
        }
    }
}
