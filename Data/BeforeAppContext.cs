using System;
using System.Collections.Generic;
using BeforeApp.Data.Entities;
using BeforeApp.Data.Entities.Connectors;
using BeforeApp.Data.Entities.Persons;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("BeforeApp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            // Seeds sample Locations
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Unknown Location",
                    City = "Unknown",
                    Adress = "Unknown"
                },
                new Location
                {
                    Id = 2,
                    Name = "Dom",
                    City = "Lodz",
                    Adress = "Off"
                },
                                new Location
                {
                    Id = 3,
                    Name = "Plener",
                    City = "Warszawa",
                    Adress = "Ul. Jeden"
                },
            };

            // Seeds sample Events
            var events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Moniker = "tekk2020waw",
                    Name = "Tekk",
                    EventDate = new DateTime(2020, 10, 18),
                    // Location = locations[0],
                    LocationId = locations[0].Id
                },

                new Event
                {
                    Id = 2,
                    Moniker = "Orga202ldz",
                    Name = "Organic",
                    EventDate = new DateTime(2021, 01, 12),
                    //Location = locations[1],
                    LocationId = locations[1].Id
                }
            };

            // Seeds sample People
            var persons = new List<Person>
            {
                new User
                {
                    Id = 1,
                    Email = "technochlopak@elo.pl",
                    Nickname = "Ziomek",
                    Birthdate = new DateTime(1985, 01, 18),
                    Sex = SexEnum.Male,
                    Orientation = "Straight",
                    Description = "Siema elo 520"
                },
                new User
                {
                    Id = 2,
                    Email = "technolaska@elo.pl",
                    Nickname = "Ziomalka",
                    Birthdate = new DateTime(1994, 01, 18),
                    Sex = SexEnum.Female,
                    Orientation = "Bi",
                    Description = "<3"
                },

                new Admin
                {
                    Id = 3,
                    Email = "admin@elo.pl",
                    Nickname = "Admin",
                    Birthdate = new DateTime(1994, 01, 18),
                    Sex = SexEnum.Other,
                    Orientation = "Bi",
                    Description = "<3"
                }
            };

            // Seeds sample MusicGenres
            var musicGenres = new List<MusicGenre>
            {
                new MusicGenre
                {
                    Id = 1,
                    Name = "Techno"
                },

                new MusicGenre
                {
                    Id = 2,
                    Name = "House"
                },

                new MusicGenre
                {
                    Id = 3,
                    Name = "Folk"
                }
            };

            // Seeds sample connectors EventMusicGenres
            var eventMusicGenres = new List<EventMusicGenres>
            {
                new EventMusicGenres
                {
                    EventId = 1,
                    MusicGenreId = 1
                },
                new EventMusicGenres
                {
                    EventId = 1,
                    MusicGenreId = 2
                },
                new EventMusicGenres
                {
                    EventId = 2,
                    MusicGenreId = 2
                }
            };

            // Seeds sample connectors PersonMusicGenres
            var personMusicGenres = new List<PersonMusicGenres>
            {
                new PersonMusicGenres
                {
                    PersonId = 1,
                    MusicGenreId = 1
                },

                new PersonMusicGenres
                {
                    PersonId = 1,
                    MusicGenreId = 2
                },

                new PersonMusicGenres
                {
                    PersonId = 2,
                    MusicGenreId = 2
                }
            };
            // Seeds sample connectors PersonEvents
            var personEvents = new List<PersonEvents>
            {
                new PersonEvents
                {
                    PersonId = 1,
                    EventId = 1
                },

                new PersonEvents
                {
                    PersonId = 1,
                    EventId = 2
                }
            };


            // Many-to-many relation between event and music genre
            bldr.Entity<EventMusicGenres>()
                .HasKey(t => new {t.EventId, t.MusicGenreId});

            bldr.Entity<EventMusicGenres>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.EventMusicGenres)
                .HasForeignKey(pt => pt.EventId);

            bldr.Entity<EventMusicGenres>()
                .HasOne(pt => pt.MusicGenre)
                .WithMany(t => t.EventMusicGenres)
                .HasForeignKey(pt => pt.MusicGenreId);

            // Many-to-many relation between person and music genres
            bldr.Entity<PersonMusicGenres>()
                .HasKey(a => new {a.PersonId, a.MusicGenreId});

            bldr.Entity<PersonMusicGenres>()
                .HasOne(ba => ba.Person)
                .WithMany(b => b.PersonMusicGenres)
                .HasForeignKey(pa => pa.PersonId);

            bldr.Entity<PersonMusicGenres>()
                .HasOne(ba => ba.MusicGenre)
                .WithMany(a => a.PersonMusicGenres)
                .HasForeignKey(ba => ba.MusicGenreId);


            // Many-to-many relation between event and person
            bldr.Entity<PersonEvents>()
                .HasKey(t => new { t.EventId, t.PersonId });

            bldr.Entity<PersonEvents>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.PersonEvents)
                .HasForeignKey(pt => pt.EventId);

            bldr.Entity<PersonEvents>()
                .HasOne(pt => pt.Person)
                .WithMany(t => t.PersonEvents)
                .HasForeignKey(pt => pt.PersonId);

            // Data seeding
            bldr.Entity<Location>().HasData(locations);
            bldr.Entity<Event>().HasData(events);
            foreach (var person in persons) bldr.Entity(person.GetType()).HasData(person);

            bldr.Entity<Person>().Property(e => e.Sex).HasConversion(
            v => v.ToString(),
            v => (SexEnum)Enum.Parse(typeof(SexEnum), v));

            bldr.Entity<MusicGenre>().HasData(musicGenres);
            bldr.Entity<EventMusicGenres>().HasData(eventMusicGenres);
            bldr.Entity<PersonMusicGenres>().HasData(personMusicGenres);
            bldr.Entity<PersonEvents>().HasData(personEvents);
        }
    }
}