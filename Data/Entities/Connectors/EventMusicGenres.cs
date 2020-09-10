using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities.Connectors
{
    public class EventMusicGenres
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int MusicGenreId { get; set; }

        public MusicGenre MusicGenre { get; set; }
    }
}
