using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geair.Persistance.Migrations
{
    public partial class update_flight_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassTitle",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassTitle",
                table: "Flights");
        }
    }
}
