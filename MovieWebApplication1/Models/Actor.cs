namespace MovieWebApplication1.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
