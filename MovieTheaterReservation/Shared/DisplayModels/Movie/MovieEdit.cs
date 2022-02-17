using MovieTheaterReservation.Shared.DisplayModels.Enums;

namespace MovieTheaterReservation.Shared.DisplayModels.Movie
{
    public class MovieEdit
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;

        public Rating Rating { get; set; }
        public int Duration { get; set; }


    }
}
