namespace session_4.Models
{
    public class BlogType
    {
        public BlogType()
        {

        }public BlogType(int id , String name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
         

    }
}
