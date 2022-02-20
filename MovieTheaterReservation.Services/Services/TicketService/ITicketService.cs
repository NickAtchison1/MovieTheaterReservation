using MovieTheaterReservation.Shared.DisplayModels.Ticket;

namespace MovieTheaterReservation.Services.Services.TicketService
{
    public interface ITicketService
    {
        Task<int> CreateTicket(TicketCreate ticketCreate, string userId);
        Task<bool> DeleteTicket(int id);
        Task<IEnumerable<TicketListItem>> GetAllTickets();
        Task<TicketDetail> GetTicket(int id);
        Task<bool> UpdateTicket(TicketEdit ticketEdit, string userId);
    }
}