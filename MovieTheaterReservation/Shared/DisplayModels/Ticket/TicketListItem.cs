using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Ticket
{
    public class TicketListItem
    {
        public int TicktId { get; set; }
        public int MovieShowingId { get; set; }
        public int SeatId { get; set; }
        public int ReservationId { get; set; }
    }
}
