using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Shared.DisplayModels.Auditorium
{
    public class AuditoriumCreate
    {
        public string Name { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = String.Empty;

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime UpdatedDate { get; set; }
    }
}
