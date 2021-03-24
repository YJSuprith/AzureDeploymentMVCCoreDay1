using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiPracticeCheckProject.Migrations
{
    public partial class MyfirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menuItems",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItems", x => x.MenuId);
                });

            migrationBuilder.InsertData(
                table: "menuItems",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[] { 101, "Watch" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menuItems");
        }
    }
}
