using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities
{
    public class User : Person
    {
        public virtual ICollection<Artist> Artists { get; set; }
        //public User()
        //{
        //    this.Events = new HashSet<Event>();
        //    this.MusicGenres = new HashSet<MusicGenre>();
        //    this.Artists = new HashSet<Artist>();
        //    this.ConnectedUsers = new HashSet<User>();
        //}
    }
}
