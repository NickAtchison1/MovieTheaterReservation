﻿using MovieTheaterReservation.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Seat
{
    public class SeatEdit
    {
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
    }
}
