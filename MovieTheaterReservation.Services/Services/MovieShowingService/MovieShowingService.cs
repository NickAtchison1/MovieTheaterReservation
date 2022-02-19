using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Shared.DisplayModels.MovieShowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.MovieShowingService
{
    public class MovieShowingService : IMovieShowingService
    {
        private readonly ApplicationDbContext _context;

        public MovieShowingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateMovieShowing(MovieShowingCreate movieShowingCreate, string userId)
        {
            var movieShowingEntity = new MovieShowing()
            {
                MovieId = movieShowingCreate.MovieId,
                AuditoriumId = movieShowingCreate.AuditoriumId,
                MovieShowingDate = movieShowingCreate.MovieShowingDate,
                MovieShowingTime = movieShowingCreate.MovieShowingTime,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now

            };
            await _context.MoviesShowings.AddAsync(movieShowingEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieShowingListItem>> GetAllMovieShowing()
        {
            var query = await _context.MoviesShowings
                .Select(m => new MovieShowingListItem()
                {
                    MovieShowingId = m.Id,
                    MovieTitle = m.Movie.Title,
                    ImageUrl = m.Movie.ImageUrl,
                    MovieShowingDate = m.Movie.CreatedDate,
                    MovieShowingTime = m.MovieShowingTime
                }).ToListAsync();
            return query;

        }

        public async Task<MovieShowingDetail> GetMovieShowing(int id)
        {
            var movieshowingEntity = await _context.MoviesShowings.SingleAsync(m => m.Id == id);
            var movieshowingDetail = new MovieShowingDetail()
            {
                MovieShowingId = movieshowingEntity.Id,
                MovieTitle = movieshowingEntity.Movie.Title,
                ImageUrl = movieshowingEntity.Movie.ImageUrl,
                Auditorium = movieshowingEntity.Auditorium.Name,
                MovieShowingDate = movieshowingEntity.MovieShowingDate,
                MovieShowingTime = movieshowingEntity.MovieShowingTime
            };
            return movieshowingDetail;
        }


        public async Task<bool> UpdateMovieShowing(MovieShowingEdit movieShowingEdit, string userId)
        {
            var movieShowingToUpdate = await _context.MoviesShowings.SingleAsync(m => m.Id == movieShowingEdit.MovieShowingId);
            movieShowingToUpdate.MovieId = movieShowingEdit.MovieId;
            movieShowingToUpdate.AuditoriumId = movieShowingEdit.AuditoriumId;
            movieShowingToUpdate.MovieShowingDate = movieShowingEdit.MovieShowingDate;
            movieShowingToUpdate.MovieShowingTime = movieShowingEdit.MovieShowingTime;
            movieShowingToUpdate.CreatedBy = movieShowingToUpdate.CreatedBy;
            movieShowingToUpdate.CreatedDate = movieShowingToUpdate.CreatedDate;
            movieShowingToUpdate.UpdatedBy = userId;
            movieShowingToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMovieShowing(int id)
        {
            var moveShowingToDelete = await _context.MoviesShowings.SingleAsync(m => m.Id == id);
            _context.MoviesShowings.Remove(moveShowingToDelete);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
