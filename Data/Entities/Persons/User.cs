using System.Collections.Generic;

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