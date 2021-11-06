using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Yol.Data.Models;

namespace YolData
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Road> Roads { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<CoordinateValue> Values { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Relation

            builder.Entity<Company>()
                .HasMany<Road>(company => company.Roads)
                .WithOne(road => road.Company);
            builder.Entity<Road>()
                .HasMany<Coordinate>(road => road.Cordinates)
                .WithOne(coordinate => coordinate.Road);
            builder.Entity<Coordinate>()
                .HasMany<CoordinateValue>(coordinate => coordinate.Values)
                .WithOne(value => value.Coordinate);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
