using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geair.Persistance.Migrations
{
    public partial class clear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denemes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denemes",
                columns: table => new
                {
                    DenemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denemes", x => x.DenemeId);
                });
        }
    }
}
