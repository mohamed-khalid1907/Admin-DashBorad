using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using session_4.Data;
using session_4.Models;
using session_4.ViewModel;
namespace session_4.Controllers
{
    public class DashBoardController : Controller
    {
        readonly ProductViewModel model = new ProductViewModel();
        private readonly ApplicationDbContext _db;
        public DashBoardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View("");
        }
        public IActionResult CreateProduct()
        {
            ProductViewModel m = new ProductViewModel();
            m.companies=_db.companies.ToList();
            return View(m);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            
            if (!ModelState.IsValid)
            {
                product.companies = _db.companies.ToList();
                return View(product.product);
            }
            product.product.company = _db.companies.Include(p=>p.Name).FirstOrDefault(p => p.Id == product.product.CompId);
            _db.products.Add(product.product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult viewproduct()
        {
            var product = _db.products.Include(p=>p.company).ToList();

            return View(product);
        } public IActionResult viewBlog()
        {
            var blog = _db.blogs.Include(p => p.blogType).ToList();

            return View(blog);
        }
        public IActionResult DeleteBlog(int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = _db.blogs.Include(x=>x.blogType).ToList().FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost ]
        public IActionResult DeleteBlog(Blog blog)
        {
            
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return RedirectToAction("viewBlog");
        }public IActionResult DeleteProduct(int?id)
        {
            var product = _db.products.Include(p => p.company).ToList();
            Product b = product.FirstOrDefault(p=>p.Id==id);
            return View(b);
        }
        [HttpPost ]
        public IActionResult DeleteProduct(Product product)
        {
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("viewProduct");
        }public IActionResult EditBlog(int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = _db.blogs.Include(x => x.blogType).ToList().FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            if (blog.blogType.Id != 0)
            {
                blog.blogType = _db.types.FirstOrDefault(b => b.Id == blog.blogType.Id);
            }
            _db.blogs.Update(blog);
            _db.SaveChanges();
            return RedirectToAction("viewBlog");
        }public IActionResult EditProduct(int?id)
        {

            var b = _db.products.Include(p=>p.company).FirstOrDefault(p=>p.Id==id);
            
            return View(b);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.company = _db.companies.FirstOrDefault(p => p.Id == product.CompId);
            _db.Update(product);
            _db.SaveChanges();
            return RedirectToAction("viewProduct");
        }public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (blog.blogType.Id != 0)
            {
                blog.blogType = _db.types.FirstOrDefault(b => b.Id == blog.blogType.Id);
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    




    }

}
