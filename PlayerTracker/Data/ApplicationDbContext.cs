using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Engines;
using PlayerTracker.Models;
using System.Collections.Generic;

namespace PlayerTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Team> Teams { get; set; }
        public DbSet <Player> Players { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedTeams(modelBuilder);
        }

        private void SeedTeams(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Gotham City Rogues" },
                new Team { Id = 2, Name = "The Mighty Ducks" },
                new Team { Id = 3, Name = "Springfield Isotopes" }
            );
        }

    }
}