using MovieTheaterReservation.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Ticket
{
    internal class TicketDetail
    {
        public int TicketId { get; set; }
        public int MovieShowingId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public Rating Rating { get; set }
        public string AuditoriumName { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int ReservationId { get; set; }
        public decimal TicketPrice { get; set; }
        public TicketType TicketType { get; set; }
        public ShowingType ShowingType { get; set; }
    }
}
