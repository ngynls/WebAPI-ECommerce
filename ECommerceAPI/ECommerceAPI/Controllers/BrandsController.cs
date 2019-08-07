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
    public class BrandsController : ControllerBase
    {
        private readonly ShopContext _context;

        public BrandsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        /// <summary>
        /// Retrieve all brands from the database
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        // GET: api/Brands/5
        /// <summary>
        /// Retrieve a particular brand
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(long id)
        {
            var b = await _context.Brands.FindAsync(id);

            if (b == null)
            {
                return NotFound();
            }

            return b;
        }

        // POST: api/Brands
        /// <summary>
        /// Submit a new brand
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand b)
        {
            _context.Brands.Add(b);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand), new { id = b.Id }, b);
        }

        // PUT: api/Brands/5
        /// <summary>
        /// Update a particular brand
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(long id, Brand b)
        {
            if (id != b.Id)
            {
                return BadRequest();
            }

            _context.Entry(b).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Brands/5
        /// <summary>
        /// Delete a particular brand
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(long id)
        {
            var b = await _context.Brands.FindAsync(id);

            if (b == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(b);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}