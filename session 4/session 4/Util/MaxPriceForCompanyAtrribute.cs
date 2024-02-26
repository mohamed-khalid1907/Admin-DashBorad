using System.ComponentModel.DataAnnotations;

namespace session_4.Util
{
    public class MaxPriceForCompanyAtrribute:ValidationAttribute
    {
        private readonly int max_price;
        public MaxPriceForCompanyAtrribute(int max)
        {
            max_price = max;    
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product = (Product) validationContext.ObjectInstance;
            int price;
            if (!int.TryParse(value.ToString(),out price)) {
                return new ValidationResult("Enter int vlaue");
            }
            if(product.CompId == 1 && price > max_price) {
                return new ValidationResult("adidas max price less than " + max_price.ToString());
            }
            return ValidationResult.Success;
        }
    }
}
