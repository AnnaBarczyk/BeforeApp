using BeforeApp.Data.Entities;
using BeforeApp.Data.Entities.Connectors;
using BeforeApp.Data.Entities.Persons;
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
        public SexEnum Sex { get; set; }
        public string Orientation { get; set; }
        public string Description { get; set; }
        public string PhotoId { get; set; }


        public virtual ICollection<PersonMusicGenres> PersonMusicGenres { get; set; }
        public virtual ICollection<PersonEvents> PersonEvents { get; set; }
        public virtual ICollection<User> ConnectedUsers { get; set; }
    }
}