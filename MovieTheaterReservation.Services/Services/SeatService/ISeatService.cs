using MovieTheaterReservation.Shared.DisplayModels.Seat;

namespace MovieTheaterReservation.Services.Services.SeatService
{
    public interface ISeatService
    {
        Task<int> CreateSeat(SeatCreate seatCreate, string userId);
        Task<bool> DeleteSeat(int id);
        Task<SeatDetail> GetSeatById(int id);
        Task<IEnumerable<SeatListItem>> GetSeats();
        Task<bool> UpdateSeat(SeatEdit seatEdit, string userId);
    }
}