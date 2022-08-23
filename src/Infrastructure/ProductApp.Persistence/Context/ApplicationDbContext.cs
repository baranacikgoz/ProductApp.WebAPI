using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Pencil", Value = 10, Quantity = 100 },
                new Product() { Id = Guid.NewGuid(), Name = "Paper", Value = 1, Quantity = 200 },
                new Product() { Id = Guid.NewGuid(), Name = "Book", Value = 15, Quantity = 500 }
                ); ;
        }
    }
}
