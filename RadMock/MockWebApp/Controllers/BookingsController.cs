using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MockConsole2.Data;
using MockLibrary.Models;


namespace MockWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly FlightContext _context;

        public BookingsController(FlightContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var flightContext = _context.Bookings.Include(b => b.Flight).Include(b => b.Passenger);
            return View(await flightContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewBag.Passengers = new SelectList(_context.Passengers, "PassengerID", "Name");
            ViewBag.Flights = new SelectList(_context.Flights, "FlightID", "FlightNumber");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,PassengerID,FlightID,TicketType,TicketCost,BaggageCharge")] Bookings booking)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            try
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Flights", new { id = booking.FlightID });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.Passengers = new SelectList(_context.Passengers, "PassengerID", "Name");
                ViewBag.Flights = new SelectList(_context.Flights, "FlightID", "FlightNumber");
                return View(booking);
            }
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            ViewData["FlightID"] = new SelectList(_context.Flights, "FlightID", "Country", bookings.FlightID);
            ViewData["PassengerID"] = new SelectList(_context.Passengers, "PassengerID", "Name", bookings.PassengerID);
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,TicketType,TicketCost,BaggageCharge,FlightID,PassengerID")] Bookings bookings)
        {
            if (id != bookings.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.BookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightID"] = new SelectList(_context.Flights, "FlightID", "Country", bookings.FlightID);
            ViewData["PassengerID"] = new SelectList(_context.Passengers, "PassengerID", "Name", bookings.PassengerID);
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings != null)
            {
                _context.Bookings.Remove(bookings);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
