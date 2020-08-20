using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities
{
    public class Event
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public Location Location { get; set; }
        public Person Publisher { get; set; }
        public ICollection<Person> UsersAttending { get; set; }
        public ICollection<MusicGenres> MusicGenres { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
