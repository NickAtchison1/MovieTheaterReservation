using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Data.Models.Enums;
using MovieTheaterReservation.Shared.DisplayModels.Seat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.SeatService
{
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;

        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSeat(SeatCreate seatCreate, string userId)
        {
            var seatEntity = new Seat()
            {
                RowNumber = seatCreate.RowNumber,
                SeatNumber = seatCreate.SeatNumber,
                SeatType = (Data.Models.Enums.SeatType)seatCreate.SeatType,
                AuditoriumId = seatCreate.AuditoriumId,

            };
            _context.Seats.Add(seatEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SeatListItem>> GetSeats()
        {
            var query = await _context.Seats
                .Select(s => new SeatListItem()
                {
                    SeatId = s.Id,
                    RowNumber = s.RowNumber,
                    SeatNumber = s.SeatNumber,
                    SeatType = (Shared.DisplayModels.Enums.SeatType)s.SeatType,
                    AuditoriumId = s.AuditoriumId

                }).ToListAsync();
            return query;
        }

        public async Task<SeatDetail> GetSeatById(int id)
        {
            var seatEntity = await _context.Seats.SingleAsync(s => s.Id == id);
            var seatDetail = new SeatDetail()
            {
                SeatId = seatEntity.Id,
                RowNumber = seatEntity.RowNumber,
                SeatNumber = seatEntity.SeatNumber,
                SeatType = (Shared.DisplayModels.Enums.SeatType)seatEntity.SeatType,
                AuditoriumId = seatEntity.AuditoriumId,
                AuditoriumName = seatEntity.Auditorium.Name
            };
            return seatDetail;
        }

        public async Task<bool> UpdateSeat(SeatEdit seatEdit, string userId)
        {
            var seatToUpdate = await _context.Seats.SingleAsync(s => s.Id == seatEdit.SeatId);
            seatToUpdate.RowNumber = seatEdit.RowNumber;
            seatToUpdate.SeatNumber = seatEdit.SeatNumber;
            seatToUpdate.SeatType = (Data.Models.Enums.SeatType)seatEdit.SeatType;
            seatToUpdate.AuditoriumId = seatEdit.AuditoriumId;
            seatToUpdate.CreatedBy = seatToUpdate.CreatedBy;
            seatToUpdate.CreatedDate = seatToUpdate.CreatedDate;
            seatToUpdate.UpdatedBy = userId;
            seatToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSeat(int id)
        {
            var seatToDeleate = await _context.Seats.SingleAsync(s => s.Id == id);
            _context.Seats.Remove(seatToDeleate);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
