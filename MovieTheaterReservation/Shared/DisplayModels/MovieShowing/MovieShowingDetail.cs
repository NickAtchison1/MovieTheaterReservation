using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.MovieShowing
{
    public class MovieShowingDetail
    {
        public int MovieShowingId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string Auditorium { get; set; } = String.Empty;
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}
