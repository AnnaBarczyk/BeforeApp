using BeforeApp.Data;
using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Models
{
    public class MusicGenreModel
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
