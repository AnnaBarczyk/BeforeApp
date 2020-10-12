using BeforeApp.Data.Entities.Connectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeforeApp.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required] public string Moniker { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public Location Location { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Person Publisher { get; set; }
        public virtual ICollection<PersonEvents> PersonEvents { get; set; }
        public virtual ICollection<EventMusicGenres> EventMusicGenres { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}