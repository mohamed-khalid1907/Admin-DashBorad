using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using session9.Data;
using session9.Models;

namespace session9.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<Company> companies = new List<Company>();
        public EditProductModel(AppDbContext db)
        {
            _db = db;
            companies = _db.companies.ToList();
        }
        [BindProperty]
        public Product product { get; set; }

        public void OnGet(int? id)
        {
            product = _db.products.FirstOrDefault(e => e.Id == id);
        }
        public IActionResult OnPost()
        {
            if (product != null)
            {
                _db.products.Update(product);
                _db.SaveChanges();
                return RedirectToPage("ViewProduct");
            }
            return Page();
           
        }
    }
}
