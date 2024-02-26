using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using session_4.Data;
using session_4.Util;

namespace session_4.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(1, 50)]
        [DeniedValues("AAA", "VVV")]
        [UniqeBlogNameAtrributecs]
        [RegularExpression(@"^[a-zA-Z' ''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z' ''-'\s]{1,40}$",
       ErrorMessage = "Characters are not allowed.")]
        public string Description { get; set; }
        public int typeId { get; set; }
        [ForeignKey ("typeId")]
        public BlogType? blogType { get; set; }

    }
}
