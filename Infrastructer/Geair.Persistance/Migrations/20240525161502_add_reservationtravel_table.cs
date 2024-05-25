using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geair.Persistance.Migrations
{
    public partial class add_reservationtravel_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelId1",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationTravels",
                columns: table => new
                {
                    ReservationTravelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTravels", x => x.ReservationTravelId);
                    table.ForeignKey(
                        name: "FK_ReservationTravels_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "TravelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTravels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravelId1",
                table: "Travels",
                column: "TravelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTravels_TravelId",
                table: "ReservationTravels",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTravels_UserId",
                table: "ReservationTravels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Travels_TravelId1",
                table: "Travels",
                column: "TravelId1",
                principalTable: "Travels",
                principalColumn: "TravelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Travels_TravelId1",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "ReservationTravels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_TravelId1",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravelId1",
                table: "Travels");
        }
    }
}
