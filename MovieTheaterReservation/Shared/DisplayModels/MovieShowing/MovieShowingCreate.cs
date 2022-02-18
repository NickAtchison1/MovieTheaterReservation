using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.MovieShowing
{
    public class MovieShowingCreate
    {
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}
