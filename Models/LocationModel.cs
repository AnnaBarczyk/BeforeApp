using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeforeApp.Data.Entities;

namespace BeforeApp.Models
{
    public class LocationModel
    {
        [Required] public string Name { get; set; }

        public string City { get; set; }
        public string Adress { get; set; }
        public ICollection<Event> Events { get; set; }
        public string Moniker { get; set; }
    }
}