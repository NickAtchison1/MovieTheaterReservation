using MovieTheaterReservation.Shared.DisplayModels.MovieShowing;

namespace MovieTheaterReservation.Services.Services.MovieShowingService
{
    public interface IMovieShowingService
    {
        Task<int> CreateMovieShowing(MovieShowingCreate movieShowingCreate, string userId);
        Task<bool> DeleteMovieShowing(int id);
        Task<IEnumerable<MovieShowingListItem>> GetAllMovieShowing();
        Task<MovieShowingDetail> GetMovieShowing(int id);
        Task<bool> UpdateMovieShowing(MovieShowingEdit movieShowingEdit, string userId);
    }
}