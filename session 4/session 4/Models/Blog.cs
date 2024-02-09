namespace session_4.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BlogType blogType { get; set; }

    }
}
