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
    public class CustomersController : ControllerBase
    {
        private readonly ShopContext _context;

        public CustomersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetProducts()
        {
            return await _context.Customers
                .ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var c = await _context.Customers.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return c;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer c)
        {
            c.RegistrationDate = DateTime.Now.ToShortDateString();
            c.Password = BCrypt.Net.BCrypt.HashPassword(c.Password);
            _context.Customers.Add(c);
            await _context.SaveChangesAsync();

            Cart cart = new Cart();
            cart.Id = c.Id;
            cart.CustomerId = c.Id;
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = c.Id }, c);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }

            _context.Entry(c).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var c = await _context.Customers.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(c);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}