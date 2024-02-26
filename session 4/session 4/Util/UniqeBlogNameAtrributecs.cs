using session_4.Data;
using session_4.Models;
using System.ComponentModel.DataAnnotations;

namespace session_4.Util
{
    public class UniqeBlogNameAtrributecs:ValidationAttribute
    {
       
        public Type db { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Blog blog = (Blog)validationContext.ObjectInstance;
            var name = (string)value;
            var _db = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
          
            foreach (var item in _db.blogs)
            {
                if (item.Name == name)
                {
                    return new ValidationResult("this name is not valid write unique name");
                } 
            }
            return ValidationResult.Success;
        }
    }
}
