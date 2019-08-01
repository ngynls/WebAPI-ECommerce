using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "PC"},
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Tablet" },
                new Category { Id = 4, Name = "Video game console" }
            );
            modelBuilder.Entity<Product>().HasData(
              new Product { Id = 1, Name = "PS4", Description= "Fourth generation of the Playstation console", ImageUrl= "https://images-na.ssl-images-amazon.com/images/I/31qwualUaLL._SR600,315_SCLZZZZZZZ_.jpg",
              Cost=399.99, Quantity=200, OutOfStock=false, CategoryId=4}
            );
        }
    }
}
