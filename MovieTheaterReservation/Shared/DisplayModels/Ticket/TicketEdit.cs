﻿using MovieTheaterReservation.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Ticket
{
    public  class TicketEdit
    {
        public int TicktId { get; set; }
        public int MovieShowingId { get; set; }
        public int SeatId { get; set; }
        public int ReservationId { get; set; }
        public decimal TicketPrice { get; set; }
        public TicketType TicketType { get; set; }
        public ShowingType ShowingType { get; set; }
    }
}
