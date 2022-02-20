using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Shared.DisplayModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateReservation(ReservationCreate reservationCreate, string userId)
        {
            var reservationEntity = new Reservation()
            {
                MovieShowingId = reservationCreate.MovieShowingId,
                ReservationType = (Data.Models.Enums.ReservationType)reservationCreate.ReservationType,
                ReservationContactType = (Data.Models.Enums.ReservationContactType)reservationCreate.ReservationContactType,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now
            };
            await _context.Reservations.AddAsync(reservationEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReservationListItem>> GetAllReservations()
        {
            var query = await _context.Reservations
                .Select(r => new ReservationListItem()
                {
                    ReservationId = r.Id,
                    Movie = r.MovieShowing.Movie.Title,
                    ReservationType = (Shared.DisplayModels.Enums.ReservationType)r.ReservationType,
                    ReservationContactType = (Shared.DisplayModels.Enums.ReservationContactType)r.ReservationContactType
                }).ToListAsync();
            return query;
        }

        public async Task<ReservationDetail> GetReservation(int id)
        {
            var reservationEntity = await _context.Reservations.SingleAsync(r => r.Id == id);
            var reservationDetail = new ReservationDetail()
            {
                ReservationId = reservationEntity.Id,
                MovieShowingId = reservationEntity.MovieShowingId,
                MovieTitle = reservationEntity.MovieShowing.Movie.Title,
                ReservationType = (Shared.DisplayModels.Enums.ReservationType)reservationEntity.ReservationType,
                ReservationContactType = (Shared.DisplayModels.Enums.ReservationContactType)reservationEntity.ReservationContactType

            };
            return reservationDetail;
        }

        public async Task<bool> UpdateReservation(ReservationEdit reservationEdit, string userId)
        {
            var reservationToUpdate = await _context.Reservations.SingleAsync(r => r.Id == reservationEdit.ReservationId);
            reservationToUpdate.MovieShowingId = reservationEdit.MovieShowingId;
            reservationToUpdate.ReservationType = (Data.Models.Enums.ReservationType)reservationEdit.ReservationType;
            reservationToUpdate.ReservationContactType = (Data.Models.Enums.ReservationContactType)reservationEdit.ReservationContactType;
            reservationToUpdate.CreatedBy = reservationToUpdate.CreatedBy;
            reservationToUpdate.CreatedDate = reservationToUpdate.CreatedDate;
            reservationToUpdate.UpdatedBy = userId;
            reservationToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var reservationToDelete = await _context.Reservations.SingleAsync(r => r.Id == id);
            _context.Reservations.Remove(reservationToDelete);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
