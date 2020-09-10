using BeforeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Models
{
    public class LocationModel
    {
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
