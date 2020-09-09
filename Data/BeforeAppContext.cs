using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeforeApp.Data
{
    public class BeforeAppContext : DbContext
    {
        private readonly IConfiguration _config;

        public BeforeAppContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        ////
        //public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("BeforeApp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {

            bldr.Entity<EventMusicGenres>()
                .HasKey(t => new { t.EventId, t.MusicGenreId });

            bldr.Entity<EventMusicGenres>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.EventMusicGenres)
                .HasForeignKey(pt => pt.EventId);

            bldr.Entity<EventMusicGenres>()
                .HasOne(pt => pt.MusicGenre)
                .WithMany(t => t.EventMusicGenres)
                .HasForeignKey(pt => pt.MusicGenreId);




            bldr.Entity<Event>().HasData(new
            {
                Id = 1,
                Moniker = "tekk2020waw",
                Name = "Tekk",
                EventDate = new DateTime(2020, 10, 18),
                LocationId = 1,
            },
                new
                {
                    Id = 2,
                    Moniker = "Orga202ldz",
                    Name = "Organic",
                    EventDate = new DateTime(2021, 01, 12),
                    LocationId = 2,
                });
            bldr.Entity<Location>().HasData(new
            {
                Id = 1,
                Name = "Plener",
                City = "Warszawa",
                Adress = "Ul. Jeden",
            },
            new
            {
                Id = 2,
                Name = "Dom",
                City = "Lodz",
                Adress = "Off",
            });

            bldr.Entity<MusicGenre>().HasData(new
            {
                Id = 1,
                Name = "Techno"
            },
            new
            {
                Id = 2,
                Name = "House"
            },

            new
            {
                Id = 3,
                Name = "Folk"
            });

        }
    }
}