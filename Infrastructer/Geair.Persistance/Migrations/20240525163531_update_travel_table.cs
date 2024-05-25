using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geair.Persistance.Migrations
{
    public partial class update_travel_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Travels_TravelId1",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_TravelId1",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravelId1",
                table: "Travels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelId1",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravelId1",
                table: "Travels",
                column: "TravelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Travels_TravelId1",
                table: "Travels",
                column: "TravelId1",
                principalTable: "Travels",
                principalColumn: "TravelId");
        }
    }
}
