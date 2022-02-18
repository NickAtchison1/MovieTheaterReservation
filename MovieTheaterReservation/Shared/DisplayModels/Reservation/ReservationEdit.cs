using MovieTheaterReservation.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Reservation
{
    public class ReservationEdit
    {
        public int ReservationId { get; set; }
        public int MovieShowingId { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
    }
}
