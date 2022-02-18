using MovieTheaterReservation.Shared.DisplayModels.Movie;

namespace MovieTheaterReservation.Services.Services.MovieService
{
    public interface IMovieService
    {
        Task<int> CreateMovie(MovieCreate movieCreate, string userId);
        Task DeleteMovieById(int id);
        Task<IEnumerable<MovieListItem>> GetAllMovies();
        Task<MovieDetail> GetMovieById(int id);
        Task<bool> UpdateMovie(MovieEdit movieEdit, string userId);
    }
}