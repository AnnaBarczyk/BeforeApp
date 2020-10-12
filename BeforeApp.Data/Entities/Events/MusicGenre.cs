using BeforeApp.Data.Entities.Connectors;
using System.Collections.Generic;

namespace BeforeApp.Data.Entities
{
    public class MusicGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventMusicGenres> EventMusicGenres { get; set; }
        public ICollection<PersonMusicGenres> PersonMusicGenres { get; set; }
    }
}