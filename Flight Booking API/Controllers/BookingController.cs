using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightapi.Models;

namespace flightapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public BookingController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KritikaBooking>>> GetKritikaBookings()
        {
            return await _context.KritikaBookings.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KritikaBooking>> GetKritikaBooking(int id)
        {
            var kritikaBooking = await _context.KritikaBookings.FindAsync(id);

            if (kritikaBooking == null)
            {
                return NotFound();
            }

            return kritikaBooking;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKritikaBooking(int id, KritikaBooking kritikaBooking)
        {
            if (id != kritikaBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(kritikaBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KritikaBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KritikaBooking>> PostKritikaBooking(KritikaBooking kritikaBooking)
        {
            _context.KritikaBookings.Add(kritikaBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKritikaBooking", new { id = kritikaBooking.BookingId }, kritikaBooking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKritikaBooking(int id)
        {
            var kritikaBooking = await _context.KritikaBookings.FindAsync(id);
            if (kritikaBooking == null)
            {
                return NotFound();
            }

            _context.KritikaBookings.Remove(kritikaBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KritikaBookingExists(int id)
        {
            return _context.KritikaBookings.Any(e => e.BookingId == id);
        }
    }
}
