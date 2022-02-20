using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Shared.DisplayModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTicket(TicketCreate ticketCreate, string userId)
        {
            var ticketEntity = new Ticket()
            {
                MovieShowingId = ticketCreate.MovieShowingId,
                SeatId = ticketCreate.SeatId,
                ReservationId = ticketCreate.ReservationId,
                TicketPrice = ticketCreate.TicketPrice,
                TicketType = (Data.Models.Enums.TicketType)ticketCreate.TicketType,
                ShowingType = (Data.Models.Enums.ShowingType)ticketCreate.ShowingType,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now,
            };
            await _context.Tickets.AddAsync(ticketEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TicketListItem>> GetAllTickets()
        {
            var query = await _context.Tickets
                .Select(t => new TicketListItem()
                {
                    TicktId = t.Id,
                    MovieShowingId = t.MovieShowingId,
                    SeatId = t.SeatId,
                    ReservationId = t.ReservationId,
                }).ToListAsync();
            return query;
        }

        public async Task<TicketDetail> GetTicket(int id)
        {
            var ticketEntity = await _context.Tickets.SingleAsync(t => t.Id == id);
            var ticketDetail = new TicketDetail()
            {
                TicketId = ticketEntity.Id,
                MovieShowingId = ticketEntity.MovieShowingId,
                MovieTitle = ticketEntity.MovieShowing.Movie.Title,
                Rating = (Shared.DisplayModels.Enums.Rating)ticketEntity.MovieShowing.Movie.Rating,
                AuditoriumName = ticketEntity.MovieShowing.Auditorium.Name,
                MovieShowingDate = ticketEntity.MovieShowing.MovieShowingDate,
                MovieShowingTime = ticketEntity.MovieShowing.MovieShowingTime,
                SeatId = ticketEntity.SeatId,
                RowNumber = ticketEntity.Seat.RowNumber,
                SeatNumber = ticketEntity.Seat.SeatNumber,
                ReservationId = ticketEntity.ReservationId,
                TicketPrice = ticketEntity.TicketPrice,
                TicketType = (Shared.DisplayModels.Enums.TicketType)ticketEntity.TicketType,
                ShowingType = (Shared.DisplayModels.Enums.ShowingType)ticketEntity.ShowingType

            };
            return ticketDetail;
        }

        public async Task<bool> UpdateTicket(TicketEdit ticketEdit, string userId)
        {
            var ticketToUpdate = await _context.Tickets.SingleAsync(t => t.Id == ticketEdit.TicketId);

            ticketToUpdate.MovieShowingId = ticketEdit.MovieShowingId;
            ticketToUpdate.SeatId = ticketEdit.SeatId;
            ticketToUpdate.ReservationId = ticketEdit.ReservationId;
            ticketToUpdate.TicketPrice = ticketEdit.TicketPrice;
            ticketToUpdate.TicketType = (Data.Models.Enums.TicketType)ticketEdit.TicketType;
            ticketToUpdate.ShowingType = (Data.Models.Enums.ShowingType)ticketEdit.ShowingType;
            ticketToUpdate.CreatedBy = ticketToUpdate.CreatedBy;
            ticketToUpdate.CreatedDate = ticketToUpdate.CreatedDate;
            ticketToUpdate.UpdatedBy = userId;
            ticketToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var ticketToDelete = await _context.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            _context.Tickets.Remove(ticketToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
