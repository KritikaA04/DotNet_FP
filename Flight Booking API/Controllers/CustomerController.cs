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
    public class CustomerController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public CustomerController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KritikaCustomer>>> GetKritikaCustomers()
        {
            return await _context.KritikaCustomers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KritikaCustomer>> GetKritikaCustomer(int id)
        {
            var kritikaCustomer = await _context.KritikaCustomers.FindAsync(id);

            if (kritikaCustomer == null)
            {
                return NotFound();
            }

            return kritikaCustomer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKritikaCustomer(int id, KritikaCustomer kritikaCustomer)
        {
            if (id != kritikaCustomer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(kritikaCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KritikaCustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KritikaCustomer>> PostKritikaCustomer(KritikaCustomer kritikaCustomer)
        {
            _context.KritikaCustomers.Add(kritikaCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKritikaCustomer", new { id = kritikaCustomer.CustomerId }, kritikaCustomer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKritikaCustomer(int id)
        {
            var kritikaCustomer = await _context.KritikaCustomers.FindAsync(id);
            if (kritikaCustomer == null)
            {
                return NotFound();
            }

            _context.KritikaCustomers.Remove(kritikaCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KritikaCustomerExists(int id)
        {
            return _context.KritikaCustomers.Any(e => e.CustomerId == id);
        }
    }
}
