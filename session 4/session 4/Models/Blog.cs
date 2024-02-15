using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace session_4.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int typeId { get; set; }
        [ForeignKey ("typeId")]
        public BlogType blogType { get; set; }

    }
}
