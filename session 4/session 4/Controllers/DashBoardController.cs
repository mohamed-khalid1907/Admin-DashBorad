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
            return View();
        }
        public IActionResult CreateProduct()
        {
            ProductViewModel model = new ProductViewModel();
            model.companies = _db.companies.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductViewModel model = new ProductViewModel();
                model.product = product;
                model.companies = _db.companies.ToList();
                return View(model);
            }
            product.company = _db.companies.FirstOrDefault(p => p.Id == product.CompId);
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("viewproduct");
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
        }public IActionResult EditBlog(int? id)
        {

            BlogViewModel model = new BlogViewModel();
            model.types = _db.types.ToList();

            var b = _db.blogs.Include(x => x.blogType).ToList().FirstOrDefault(b => b.Id == id);
            model.blog = b;
            return View(model);
        }
            
            
        [HttpPost]
        public IActionResult EditBlog(BlogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            model.blog.blogType = _db.types.FirstOrDefault(b => b.Id == model.blog.typeId);
            _db.Update(model.blog);
            _db.SaveChanges();
            return RedirectToAction("viewBlog");
        }public IActionResult EditProduct(int?id)
        {
            ProductViewModel model = new ProductViewModel();
            model.companies = _db.companies.ToList();
           
            var b = _db.products.Include(p=>p.company).FirstOrDefault(p=>p.Id==id);
            model.product = b;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductViewModel model = new ProductViewModel();
                model.product = product;
                model.companies = _db.companies.ToList();
                return View(model);
            }
        
            product.company = _db.companies.FirstOrDefault(p => p.Id == product.CompId);
            _db.products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("viewProduct");
        }public IActionResult AddBlog()
        {
            BlogViewModel model = new BlogViewModel();
            model.types = _db.types.ToList();
            return View(model);
            
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            if (!ModelState.IsValid)
            {
                BlogViewModel model = new BlogViewModel();
                model.blog = blog;
                model.types = _db.types.ToList();
                return View(model);
            }
            blog.blogType = _db.types.FirstOrDefault(b => b.Id == blog.typeId);
            
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    




    }

}
