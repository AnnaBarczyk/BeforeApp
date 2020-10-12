using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeforeApp.Domain.Models
{
    public class MusicGenreModel
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
