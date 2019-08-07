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
    public class OrdersController : ControllerBase
    {
        private readonly ShopContext _context;

        public OrdersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        /// <summary>
        /// Retrieve all orders from the database
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(c => c.Customer)
                .ToListAsync();
        }


        // GET: api/Orders/5
        /// <summary>
        /// Retrieve a particular order
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var o = await _context.Orders.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            _context.Entry(o)
                .Reference(order => order.Customer)
                .Load();

            return o;
        }

        // GET: api/Orders/ByCustomer/id
        /// <summary>
        /// Retrieve all orders for a particular customer
        /// </summary>
        [HttpGet("byCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(long id)
        {
            return await _context.Orders
                .Where(c => c.CustomerId == id)
                .ToListAsync();
        }

        // POST: api/Orders
        /// <summary>
        /// Submit a new order
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/Orders
        ///     {
        ///         "dateIssued": "8/7/2019"
        ///         "shippedDate": "TBD",
        ///         "status": "Processing",
        ///         "subTotal": 50.00,
        ///         "tPSTax": 2.50,
        ///         "tVQTax": 4.88,
        ///         "total" : 57.38,
        ///         "paymentType": "CC",
        ///         "customerId": 1
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order o)
        {
            _context.Orders.Add(o);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = o.Id }, o);
        }

        // PUT: api/Orders/5
        /// <summary>
        /// Update a particular order
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, Order o)
        {
            if (id != o.Id)
            {
                return BadRequest();
            }

            _context.Entry(o).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Orders/5
        /// <summary>
        /// Delete a particular order
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var o = await _context.Orders.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(o);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}