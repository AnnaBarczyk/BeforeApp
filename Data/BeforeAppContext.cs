using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeforeApp.Data.Entities;
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
    }
}