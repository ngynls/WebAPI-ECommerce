﻿// <auto-generated />
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ECommerceAPI.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ECommerceAPI.Models.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Sony"
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Video game console"
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BrandId");

                    b.Property<long>("CategoryId");

                    b.Property<double>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<bool>("OutOfStock");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BrandId = 1L,
                            CategoryId = 4L,
                            Cost = 399.99000000000001,
                            Description = "Fourth generation of the Playstation console",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/31qwualUaLL._SR600,315_SCLZZZZZZZ_.jpg",
                            Name = "PS4",
                            OutOfStock = false,
                            Quantity = 200
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Product", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerceAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
