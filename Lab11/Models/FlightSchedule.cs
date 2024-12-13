using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class FlightSchedule
    {
        public int ScheduleId { get; set; }

        public int FlightId { get; set; }

        public DateTime DepartureDate { get; set; }

        public Flight Flight { get; set; }
    }
}
