using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechPulse.DAL.Enums;
using TechPulse.DAL.Models;

namespace TechPulse.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .Property(p => p.Category)
            .HasConversion<string>();

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "GPT-5 Redefines Language Model Benchmarks", Category = Category.AI, Description = "OpenAI's latest model sets new records in reasoning and coding tasks.", PublishedAt = new DateTime(2026, 5, 31) },
                new Post { Id = 2, Title = "Angular 19 Signals API Changes State Management", Category = Category.WebDevelopment, Description = "The new signals-based approach eliminates the need for NgRx in most apps.", PublishedAt = new DateTime(2026, 5, 31) },
                new Post { Id = 3, Title = "Critical Zero-Day Vulnerability Patched in Cloud Providers", Category = Category.Security, Description = "Security researchers disclosed a widespread flaw affecting cloud instances.", PublishedAt = new DateTime(2026, 5, 31) }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
