using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeforeApp.Data;
using BeforeApp.Data.Entities;

namespace BeforeApp.Models
{
    public class EventModel
    {
        [Required]
        [StringLength(20)]
        // [Unique] to check
        public string Moniker { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public DateTime EventDate { get; set; }

        public Location Location { get; set; }
        public Person Publisher { get; set; }
        public ICollection<Person> UsersAttending { get; set; }
        public ICollection<MusicGenre> MusicGenres { get; set; }
        public ICollection<Artist> Artists { get; set; }


        public string LocationName { get; set; }
        public string LocationCity { get; set; }
        public string LocationAdress { get; set; }
    }
}