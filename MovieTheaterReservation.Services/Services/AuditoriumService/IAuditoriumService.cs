using MovieTheaterReservation.Shared.DisplayModels.Auditorium;

namespace MovieTheaterReservation.Services.Services.AuditoriumService
{
    public interface IAuditoriumService
    {
        Task<int> CreateAuditorium(AuditoriumCreate auditoriumCreate, string userId);
        Task<bool> DeleteAuditorium(int id);
        Task<IEnumerable<AuditoriumListItem>> GetAllAuditoriums();
        Task<AuditoriumDetail> GetAuditoriumById(int id);
        Task<bool> UpdateAuditorium(AuditoriumEdit auditoriumEdit, string userId);
    }
}