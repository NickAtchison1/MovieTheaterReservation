using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterReservation.Data.Data.Migrations
{
    public partial class ChangeTicketToTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MoviesShowings_MovieShowingId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Reservations_ReservationId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seats_SeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_SeatId",
                table: "Tickets",
                newName: "IX_Tickets_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ReservationId",
                table: "Tickets",
                newName: "IX_Tickets_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_MovieShowingId",
                table: "Tickets",
                newName: "IX_Tickets_MovieShowingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MoviesShowings_MovieShowingId",
                table: "Tickets",
                column: "MovieShowingId",
                principalTable: "MoviesShowings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MoviesShowings_MovieShowingId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SeatId",
                table: "Ticket",
                newName: "IX_Ticket_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReservationId",
                table: "Ticket",
                newName: "IX_Ticket_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_MovieShowingId",
                table: "Ticket",
                newName: "IX_Ticket_MovieShowingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MoviesShowings_MovieShowingId",
                table: "Ticket",
                column: "MovieShowingId",
                principalTable: "MoviesShowings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Reservations_ReservationId",
                table: "Ticket",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seats_SeatId",
                table: "Ticket",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
