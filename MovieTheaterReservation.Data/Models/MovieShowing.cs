using MovieTheaterReservation.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Data.Models
{
    public class MovieShowing : BaseRequirement
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
        public Movie? Movie { get; set; }
        public Auditorium? Auditorium { get; set; }
    }
}
