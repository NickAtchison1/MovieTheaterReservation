using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Auditorium
{
    public class AuditoriumEdit
    {
        public int AuditoriumId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

    }
}
