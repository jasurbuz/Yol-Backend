using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Yol.Data.Configuration;
using Yol.Data.Models;
using Yol.Data.Models.Indentity;

namespace YolData
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        #region Public mambers

        public DbSet<Road> Roads { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Image> Images { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Relation

            builder.Entity<Company>()
                .HasMany<Road>(company => company.Roads)
                .WithOne(road => road.Company);
            builder.Entity<Road>()
                .HasMany<Image>(road => road.Images)
                .WithOne(image => image.Road);
            
            builder.Entity<Admin>()
                .HasMany<News>(user => user.News)
                .WithOne(news => news.Admin);

            builder.Entity<Admin>()
                .HasMany<Road>(user => user.Roads)
                .WithOne(road => road.Admin);
            #endregion

            builder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
