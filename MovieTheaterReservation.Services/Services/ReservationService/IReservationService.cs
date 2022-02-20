using MovieTheaterReservation.Shared.DisplayModels.Reservation;

namespace MovieTheaterReservation.Services.Services.ReservationService
{
    public interface IReservationService
    {
        Task<int> CreateReservation(ReservationCreate reservationCreate, string userId);
        Task<bool> DeleteReservation(int id);
        Task<IEnumerable<ReservationListItem>> GetAllReservations();
        Task<ReservationDetail> GetReservation(int id);
        Task<bool> UpdateReservation(ReservationEdit reservationEdit, string userId);
    }
}