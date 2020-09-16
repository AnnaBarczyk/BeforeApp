﻿using System.Collections.Generic;
using BeforeApp.Data.Entities.Connectors;

namespace BeforeApp.Data.Entities
{
    public class MusicGenre
    {
        //public MusicGenre()
        //{
        //    this.Events = new HashSet<Event>();
        //}

        public int Id { get; set; }

        public string Name { get; set; }

        //[NotMapped]
        public ICollection<EventMusicGenres> EventMusicGenres { get; set; }
        public ICollection<PersonMusicGenres> PersonMusicGenres { get; set; }
    }
}