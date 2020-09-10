using BeforeApp.Data.Entities;
using BeforeApp.Data.Entities.Connectors;
using System;
using System.Collections.Generic;

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
        public virtual ICollection<PersonMusicGenres> PersonMusicGenres { get; set; }
        public virtual ICollection<User> ConnectedUsers { get; set; }


    }
}
