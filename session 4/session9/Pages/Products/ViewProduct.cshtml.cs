using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using session9.Data;
using session9.Models;

namespace session9.Pages.Products
{
    public class ViewProductModel(AppDbContext _db) : PageModel
    {
        public List<Product> products = new List<Product>();
        public List<Company> companies = new List<Company>();

        public void OnGet()
        {
            products = _db.products.ToList();
            companies = _db.companies.ToList();
        }
    }
}
