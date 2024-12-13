using Lab11.Data;
using Lab11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Controllers
{
    public class AirportController : Controller
    {
        private readonly AirportDbContext _context;

        public AirportController(AirportDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights.ToListAsync();
            return View(flights);
        }

        public async Task<IActionResult> Detail(int flightId)
        {
            var flightSchedule = await _context.FlightSchedules
                .Include(fs => fs.Flight)
                .Where(fs => fs.FlightId == flightId)
                .FirstOrDefaultAsync();

            return View(flightSchedule);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var flight = new Flight();
            return View(flight);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Flight flight)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        Console.WriteLine($"Key: {state.Key}");
                        foreach (var error in state.Value.Errors)
                        {
                            Console.WriteLine($"Error: {error.ErrorMessage}");
                        }
                    }
                }
                if (ModelState.IsValid)
                {
                    await _context.Flights.AddAsync(flight);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            Console.WriteLine($"FlightNumber: {flight.FlightNumber}, Destination: {flight.Destination}");
            return View(flight);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            return View(flight);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind("FlightId,FlightNumber,Destination")] Flight flight)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Flights.Update(flight);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(flight);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            return View(flight);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var flight = await _context.Flights.FindAsync(id);
            try
            {
                if (flight != null)
                {
                    _context.Flights.Remove(flight);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(flight);
        }
    }
}
