using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Data.Models
{
    public class Auditorium : BaseRequirement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Seat> Seat { get; set; } = new HashSet<Seat>();
        public ICollection<MovieShowing> MovieShowing { get; set; } = new HashSet<MovieShowing>();
  
    }
}
