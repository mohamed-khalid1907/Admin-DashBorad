using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using session9.Data;
using session9.Models;

namespace session9.Pages.Products
{
    
    public class DeleteProductModel(AppDbContext _db) : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int? id)
        {
              product = _db.products.FirstOrDefault(e => e.Id == id);
        }
        public IActionResult OnPost() {
            
            if (product != null)
            {
                _db.products.Remove(product);
                _db.SaveChanges();
                return RedirectToPage("ViewProduct");
            }
            return Page();

        }
    }
}
