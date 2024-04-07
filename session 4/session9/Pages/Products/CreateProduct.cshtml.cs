using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using session9.Data;
using session9.Models;

namespace session9.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        
        private readonly AppDbContext _db;
        public List<Company> companies = new List<Company>();
        public CreateProductModel(AppDbContext db)
        {
            _db = db;
            companies = _db.companies.ToList();
        }
        [BindProperty]
        public Product product { get; set; }
        
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToPage("ViewProduct");
        }
    }
}
