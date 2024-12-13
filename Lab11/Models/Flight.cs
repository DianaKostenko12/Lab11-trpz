using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Flight number is required.")]
        [StringLength(10, ErrorMessage = "Flight number cannot exceed 10 characters.")]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [StringLength(100, ErrorMessage = "Destination cannot exceed 100 characters.")]
        public string Destination { get; set; }

        public ICollection<FlightSchedule> FlightSchedules { get; set; } = new List<FlightSchedule>();
    }
}
