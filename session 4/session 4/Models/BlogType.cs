using System.ComponentModel.DataAnnotations;

namespace session_4.Models
{
    public class BlogType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
         

    }
}
