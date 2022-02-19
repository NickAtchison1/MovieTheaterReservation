using MovieTheaterReservation.Shared.DisplayModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterReservation.Shared.DisplayModels.Movie
{
    public class MovieEdit
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }
        [Required]
        public string UpdatedBy { get; set; } = string.Empty;
        
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }


    }
}
