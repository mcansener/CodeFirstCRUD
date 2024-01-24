﻿using CodeFirstCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstCRUD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
