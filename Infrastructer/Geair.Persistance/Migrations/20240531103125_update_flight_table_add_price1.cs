using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geair.Persistance.Migrations
{
    public partial class update_flight_table_add_price1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flights",
                newName: "EconomyPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "BusinessPrice",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessPrice",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "EconomyPrice",
                table: "Flights",
                newName: "Price");
        }
    }
}
