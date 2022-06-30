using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Backend.Migrations
{
    public partial class what : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Whats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description1 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Whats");
        }
    }
}
