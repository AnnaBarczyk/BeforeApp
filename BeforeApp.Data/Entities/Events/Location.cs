using System.Collections.Generic;

namespace BeforeApp.Data.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public ICollection<Event> Events { get; set; }
        public string Moniker { get; set; }
    }
}