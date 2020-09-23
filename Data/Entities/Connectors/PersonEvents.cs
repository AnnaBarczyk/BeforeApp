
namespace BeforeApp.Data.Entities.Connectors
{
    public class PersonEvents
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
