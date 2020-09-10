﻿using BeforeApp.Data.Entities.Connectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeforeApp.Data.Entities
{
    public class Event
    {

        //public Event()
        //{
        //    this.UsersAttending = new HashSet<User>();
        //    this.MusicGenres = new HashSet<MusicGenre>();
        //    this.Artists = new HashSet<Artist>();

        //}
        public int Id { get; set; }
        [Required]
        public string Moniker { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public Location Location { get; set; }
        public Person Publisher { get; set; }
        public virtual ICollection<User> UsersAttending { get; set; }
        public virtual ICollection<EventMusicGenres> EventMusicGenres { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
