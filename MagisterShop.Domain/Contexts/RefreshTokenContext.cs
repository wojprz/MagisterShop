using MagisterShop.Domain.Entities;
using MagisterShop.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Domain.Contexts
{
    public class RefreshTokenContext : DbContext
    {
        private readonly SqlSettings _settings;

        public RefreshTokenContext(DbContextOptions<RefreshTokenContext> options, IOptions<SqlSettings> sqlSettings) : base(options)
        {
            _settings = sqlSettings.Value;
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_settings.ConnectionString,
                options =>
                {
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var itemBuilder = modelBuilder.Entity<RefreshToken>();
            itemBuilder.HasKey(x => x.Id);
            modelBuilder.Entity<RefreshToken>().ToTable("RefreshTokens");
        }
    }
}
