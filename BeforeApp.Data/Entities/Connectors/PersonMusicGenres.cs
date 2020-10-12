namespace BeforeApp.Data.Entities.Connectors
{
    public class PersonMusicGenres
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int MusicGenreId { get; set; }

        public MusicGenre MusicGenre { get; set; }
    }
}