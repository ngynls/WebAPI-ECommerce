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
    public class OrderDetailsController : ControllerBase
    {
        private readonly ShopContext _context;

        public OrderDetailsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        /// <summary>
        /// Retrieve all order details from the database
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            return await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .ToListAsync();
        }

        // GET: api/OrderDetails/5
        /// <summary>
        /// Retrieve a particular order detail
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var o = await _context.OrderDetails.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            _context.Entry(o)
                .Reference(order => order.Order)
                .Load();

            _context.Entry(o)
                .Reference(order => order.Product)
                .Load();

            return o;
        }

        // POST: api/OrderDetails
        /// <summary>
        /// Submit a new order detail
        /// </summary>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST api/OrderDetails
        ///     {
        ///         "orderId": 1,
        ///         "productId": 1,
        ///         "quantity" 1
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail o)
        {
            _context.OrderDetails.Add(o);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetail), new { id = o.Id }, o);
        }

        // PUT: api/OrderDetails/5
        /// <summary>
        /// Update a particular order detail
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetails(long id, OrderDetail o)
        {
            if (id != o.Id)
            {
                return BadRequest();
            }

            _context.Entry(o).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/OrderDetails/5
        /// <summary>
        /// Delete a particular order detail
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(long id)
        {
            var o = await _context.OrderDetails.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(o);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}