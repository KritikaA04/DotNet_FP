using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightapi.Models;
using flightapi.Service;

namespace flightapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightServ<KritikaFlight> _flightserv;

        public FlightController(IFlightServ<KritikaFlight> flightserv)
        {
            _flightserv = flightserv;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KritikaFlight>>> GetKritikaFlights()
        {
            // return await _context.KritikaFlights.ToListAsync();
            return _flightserv.ShowAllFlights();

        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KritikaFlight>> GetKritikaFlight(int id)
        {
            var kritikaFlight = _flightserv.GetFlight(id);

            if (kritikaFlight == null)
            {
                return NotFound();
            }

            return kritikaFlight;
        }

        // PUT: api/Flight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKritikaFlight(int id, KritikaFlight kritikaFlight)
        {
            if (id != kritikaFlight.FlightId)
            {
                return BadRequest();
            }

            // _context.Entry(kritikaFlight).State = EntityState.Modified;
           
            try
            {
                // await _context.SaveChangesAsync();
                 _flightserv.UpdateFlight(id, kritikaFlight);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KritikaFlightExists(id))
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

        // POST: api/Flight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KritikaFlight>> PostKritikaFlight(KritikaFlight kritikaFlight)
        {
            // _context.KritikaFlights.Add(kritikaFlight);
            try
            {
                // await _context.SaveChangesAsync();
                _flightserv.AddFlight(kritikaFlight);
            }
            catch (DbUpdateException)
            {
                if (KritikaFlightExists(kritikaFlight.FlightId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKritikaFlight", new { id = kritikaFlight.FlightId }, kritikaFlight);
        }

        // DELETE: api/Flight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKritikaFlight(int id)
        {
            var kritikaFlight = _flightserv.GetFlight(id);
            if (kritikaFlight == null)
            {
                return NotFound();
            }

            _flightserv.DeleteFlight(id);
            // await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KritikaFlightExists(int id)
        {
            // return _context.KritikaFlights.Any(e => e.FlightId == id);
            KritikaFlight kritikaFlight= _flightserv.GetFlight(id);
            if(kritikaFlight!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
