using BeforeApp.Data.Entities.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

    }

}
