using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public string Orientation { get; set; }
        public string Description { get; set; }
        public string PhotoId { get; set; }

       // [NotMapped]
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<MusicGenre> MusicGenres { get; set; }
        public virtual ICollection<User> ConnectedUsers { get; set; }


    }
}
