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
    public class CategoriesController : ControllerBase
    {
        private readonly ShopContext _context;

        public CategoriesController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        /// <summary>
        /// Retrieve all categories from the database
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        /// <summary>
        /// Retrieve a particular category
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var c = await _context.Categories.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return c;
        }

        // POST: api/Categories
        /// <summary>
        /// Submit a new category
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     
        ///     POST api/Categories
        ///     {
        ///         "name": "CategoryName"
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category c)
        {
            _context.Categories.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = c.Id }, c);
        }

        // PUT: api/Categories/5
        /// <summary>
        /// Update a particular category
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }

            _context.Entry(c).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Categories/5
        /// <summary>
        /// Delete a particular category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var c = await _context.Categories.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(c);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}