using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterReservation.Data.Data.Migrations
{
    public partial class AddImageUrlFieldToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Ticket_Auditoriums_AuditoriumId",
            //    table: "Ticket");

            //migrationBuilder.DropIndex(
            //    name: "IX_Ticket_AuditoriumId",
            //    table: "Ticket");

            //migrationBuilder.DropColumn(
            //    name: "AuditoriumId",
            //    table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "AuditoriumId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AuditoriumId",
                table: "Ticket",
                column: "AuditoriumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Auditoriums_AuditoriumId",
                table: "Ticket",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "Id");
        }
    }
}
