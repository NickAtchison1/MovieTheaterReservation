using MovieTheaterReservation.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Data.Models
{
    public class Ticket : BaseRequirement
    {
        public int Id { get; set; }
        public int MovieShowingId { get; set; }
        public int SeatId { get; set; }
        public int ReservationId { get; set; }
        public decimal TicketPrice { get; set; }
        public TicketType TicketType { get; set; }
        public ShowingType ShowingType { get; set; }
        public MovieShowing? MovieShowing { get; set; }
        public Seat? Seat { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
