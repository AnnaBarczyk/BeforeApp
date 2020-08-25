using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Moniker { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public Location Location { get; set; }
        public Person Publisher { get; set; }
        public virtual ICollection<Person> UsersAttending { get; set; }
        public virtual ICollection<MusicGenre> MusicGenres { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
