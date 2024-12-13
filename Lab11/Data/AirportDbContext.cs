using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Data
{
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightId);

            modelBuilder.Entity<FlightSchedule>()
                .HasKey(fs => fs.ScheduleId);

            modelBuilder.Entity<FlightRoute>()
                .HasKey(fr => fr.RouteId);

            modelBuilder.Entity<FlightSchedule>()
                .HasOne(fs => fs.Flight)
                .WithMany(f => f.FlightSchedules)
                .HasForeignKey(fs => fs.FlightId);

            modelBuilder.Entity<FlightRoute>()
                .HasOne(fr => fr.Flight)
                .WithMany()
                .HasForeignKey(fr => fr.FlightId);

            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightId = 1, FlightNumber = "AA123", Destination = "New York" },
                new Flight { FlightId = 2, FlightNumber = "BA456", Destination = "London" },
                new Flight { FlightId = 3, FlightNumber = "CA789", Destination = "Tokyo" }
            );

            modelBuilder.Entity<FlightSchedule>().HasData(
                new FlightSchedule { ScheduleId = 1, FlightId = 1, DepartureDate = DateTime.Today },
                new FlightSchedule { ScheduleId = 2, FlightId = 2, DepartureDate = DateTime.Today.AddDays(1) },
                new FlightSchedule { ScheduleId = 3, FlightId = 3, DepartureDate = DateTime.Today }
            );

            modelBuilder.Entity<FlightRoute>().HasData(
                new FlightRoute { RouteId = 1, FlightId = 1, RouteDetails = "NYC to JFK" },
                new FlightRoute { RouteId = 2, FlightId = 2, RouteDetails = "LHR to Heathrow" },
                new FlightRoute { RouteId = 3, FlightId = 3, RouteDetails = "HND to Narita" }
            );
        }
    }
}
