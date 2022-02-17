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
    public class Seat : BaseRequirement
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
      
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
        public Auditorium? Auditorium { get; set; }
        //[Required]
        //public string CreatedBy { get; set; } = string.Empty;
        //[Required]
        //[Column(TypeName = "datetime2")]
        //public DateTime CreatedDate { get; set; }
        //[Required]
        //public string UpdatedBy { get; set; } = string.Empty;
        //[Required]
        //[Column(TypeName = "datetime2")]
        //public DateTime UpdatedDate { get; set; }
    }
}
