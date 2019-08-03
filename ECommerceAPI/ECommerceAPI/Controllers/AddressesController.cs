using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ShopContext _context;

        public AddressesController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Addresses
                .ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var a = await _context.Addresses.FindAsync(id);

            if (a == null)
            {
                return NotFound();
            }

            return a;
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address a)
        {
            _context.Addresses.Add(a);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddress), new { id = a.Id }, a);
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(long id, Address a)
        {
            if (id != a.Id)
            {
                return BadRequest();
            }

            _context.Entry(a).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(long id)
        {
            var a = await _context.Addresses.FindAsync(id);

            if (a == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(a);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}