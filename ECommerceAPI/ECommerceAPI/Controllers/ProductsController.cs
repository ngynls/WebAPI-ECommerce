﻿using System;
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
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Products
        /// <summary>
        /// Retrieve all products from the database
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToListAsync();
        }

        // GET: api/Products/5
        /// <summary>
        /// Retrieve a particular product
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var p = await _context.Products.FindAsync(id);

            if (p == null)
            {
                return NotFound();
            }

            _context.Entry(p)
                .Reference(prod => prod.Category)
                .Load();

            _context.Entry(p)
                .Reference(prod => prod.Brand)
                .Load();

            return p;
        }

        // POST: api/Products
        /// <summary>
        /// Submit a new product
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     
        ///     POST api/Products
        ///     {
        ///         "name": "ProductName",
        ///         "description": "A description here",
        ///         "imageUrl": "https://yourwebsite.com/images/image1.jpg",
        ///         "cost": 99.99,
        ///         "quantity": 200,
        ///         "outOfStock": false,
        ///         "categoryId" 1
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = p.Id }, p);
        }

        // PUT: api/Products/5
        /// <summary>
        /// Update a particular product
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Products/5
        /// <summary>
        /// Delete a particular product
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var p = await _context.Products.FindAsync(id);

            if (p == null)
            {
                return NotFound();
            }

            _context.Products.Remove(p);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}