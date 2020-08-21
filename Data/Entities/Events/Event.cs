using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Moniker { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public Person Publisher { get; set; }
        public ICollection<Person> UsersAttending { get; set; }
        public ICollection<MusicGenre> MusicGenres { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
