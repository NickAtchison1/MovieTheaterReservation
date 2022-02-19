using MovieTheaterReservation.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Data.Models
{

    public class Movie : BaseRequirement
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }
        public ICollection<MovieShowing> MovieShowing { get; set; } = new HashSet<MovieShowing>();
       
    }
}
