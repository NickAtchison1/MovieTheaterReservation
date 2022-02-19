using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Shared.DisplayModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateMovie(MovieCreate movieCreate, string userId)
        {
            var movieEntity = new Movie()
            {
                Title = movieCreate.Title,
                Rating = (Data.Models.Enums.Rating)movieCreate.Rating,
                //(Data.Models.Enums.Rating)(Shared.DisplayModels.Enums.Rating)movieCreate.Rating,
                Duration = movieCreate.Duration,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now

            };
            await _context.Movies.AddAsync(movieEntity);
           return  await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieListItem>> GetAllMovies()
        {
            var query = await _context.Movies
                .Select(m => new MovieListItem()
                {
                    Title = m.Title,
                    Rating = (Shared.DisplayModels.Enums.Rating)m.Rating,
                }).ToListAsync();
            return query;
        }

        public async Task<MovieDetail> GetMovieById(int id)
        {
            var movieEntity = await _context.Movies.SingleAsync(m => m.Id == id);
            var movieDetail = new MovieDetail()
            {
                MovieId = movieEntity.Id,
                Title = movieEntity.Title,
                Rating = (Shared.DisplayModels.Enums.Rating)movieEntity.Rating,
                Duration = movieEntity.Duration
            };
            return movieDetail;
        }

        public async Task<bool> UpdateMovie(MovieEdit movieEdit, string userId)
        {
            var movieToUpdate = await _context.Movies.SingleAsync(m => m.Id == movieEdit.MovieId);
            movieToUpdate.Title = movieEdit.Title;
            movieToUpdate.Rating = (Data.Models.Enums.Rating)movieEdit.Rating;
            movieToUpdate.Duration = movieEdit.Duration;
            movieToUpdate.CreatedBy = movieToUpdate.CreatedBy;
            movieToUpdate.CreatedDate = movieToUpdate.CreatedDate;
            movieToUpdate.UpdatedBy = userId;
            movieToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteMovieById(int id)
        {
            var movieToDelete = await _context.Movies.SingleAsync(m => m.Id == id);
            _context.Movies.Remove(movieToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
