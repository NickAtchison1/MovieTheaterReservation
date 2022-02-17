using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Data.Models
{
    public abstract class BaseRequirement
    {
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; } 
        [Required]
        public string UpdatedBy { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }
    }
}
