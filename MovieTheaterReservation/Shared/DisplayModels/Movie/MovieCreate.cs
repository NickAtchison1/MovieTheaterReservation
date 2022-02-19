using MovieTheaterReservation.Shared.DisplayModels.Enums;

namespace MovieTheaterReservation.Shared.DisplayModels.Movie
{
    public class MovieCreate
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl {  get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }


    }
}
