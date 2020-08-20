using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BeforeApp.Data
{
    public abstract class Person
    {
        public MailAddress Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public Enum Sex { get; set; }
        public Enum Orientation { get; set; }
        public string Description { get; set; }
        public string PhotoId { get; set; }
        public  ICollection<MusicGenres> FavMusicGenres { get; set; }
        public ICollection<User> ConnectedUsers { get; set; }
        public ICollection<Artist> FavArtists { get; set; }

    }
}
