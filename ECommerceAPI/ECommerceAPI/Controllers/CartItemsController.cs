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
    public class CartItemsController : ControllerBase
    {
        private readonly ShopContext _context;

        public CartItemsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .ToListAsync();
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var i = await _context.CartItems.FindAsync(id);

            if (i == null)
            {
                return NotFound();
            }

            _context.Entry(i)
                .Reference(item => item.Cart)
                .Load();

            _context.Entry(i)
                .Reference(item => item.Product)
                .Load();

            return i;
        }

        // GET: api/CartItems
        [HttpGet("byCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItemsByCustomer(long id)
        {
            return await _context.CartItems
                .Where(c => c.CartId == id)
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .ToListAsync();
        }

        // POST: api/CartItems
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem i)
        {
            _context.CartItems.Add(i);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartItem), new { id = i.Id }, i);
        }

        // PUT: api/CartItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(long id, CartItem i)
        {
            if (id != i.Id)
            {
                return BadRequest();
            }

            _context.Entry(i).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(long id)
        {
            var i = await _context.CartItems.FindAsync(id);

            if (i == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(i);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}