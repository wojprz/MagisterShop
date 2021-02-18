using System;
using System.Collections.Generic;
using System.Text;
using MagisterShop.Domain.Entities;
using MagisterShop.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MagisterShop.Domain.Contexts
{
    public class MagisterShopContext : DbContext
    {
        private readonly IOptions<SqlSettings> _settings;

        public MagisterShopContext(DbContextOptions<MagisterShopContext> options, IOptions<SqlSettings> sqlSettings) : base(options)
        {
            _settings = sqlSettings;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Rating>().ToTable("Ratings");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MagisterShop");
        }

        public object Clone()
        {
            return new MagisterShopContext(new DbContextOptions<MagisterShopContext>(), _settings);
        }
    }
}
