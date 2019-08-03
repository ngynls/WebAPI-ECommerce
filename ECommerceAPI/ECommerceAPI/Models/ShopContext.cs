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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "PC"},
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Tablet" },
                new Category { Id = 4, Name = "Video game console" }
            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Sony" }
            );
            modelBuilder.Entity<Product>().HasData(
              new Product { Id = 1, Name = "PS4", Description= "Fourth generation of the Playstation console", ImageUrl= "https://images-na.ssl-images-amazon.com/images/I/31qwualUaLL._SR600,315_SCLZZZZZZZ_.jpg",
              Cost=399.99, Quantity=200, OutOfStock=false, CategoryId=4, BrandId=1}
            );
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Montreal" },
                new City { Id = 2, Name = "Toronto"}
            );
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, Name = "Quebec" },
                new Province { Id = 2, Name = "Ontario" }
            );
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Canada" }
            );
        }
    }
}
