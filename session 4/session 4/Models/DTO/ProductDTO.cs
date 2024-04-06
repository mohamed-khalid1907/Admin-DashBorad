using session_4.Util;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace session_4.Models.DTO
{
    public class ProductDTO
    {

    
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "not valid name")]
        [Length(1, 50)]
        [DeniedValues("AAA", "VVV")]
        [RegularExpression(@"^[a-zA-Z' ''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(100, 10000
            , ErrorMessage = "not in the range.")]
         
        public int Price { get; set; }

        /*[Required]
        public int Quantity { get; set; }
*/
/*        public bool EnableSize { get; set; }*/
        [Required]
        public int CompId { get; set; }

    
        public Company? company { get; set; }
    }
}
