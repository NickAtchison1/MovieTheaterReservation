using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.MovieShowing
{
    public class MovieShowingListItem
    {
        public int MovieShowingId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}
