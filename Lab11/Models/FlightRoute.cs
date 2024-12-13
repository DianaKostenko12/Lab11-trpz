using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class FlightRoute
    {
        public int RouteId { get; set; }

        public int FlightId { get; set; }

        public string RouteDetails { get; set; }

        public Flight Flight { get; set; }
    }
}
