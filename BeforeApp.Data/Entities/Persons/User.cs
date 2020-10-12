using System.Collections.Generic;

namespace BeforeApp.Data.Entities
{
    public class User : Person
    {
        public virtual ICollection<Artist> Artists { get; set; }
    }
}