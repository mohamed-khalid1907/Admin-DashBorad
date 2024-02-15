using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session_4.Data;
using session_4.Models;
namespace session_4.Controllers
{
    public class DashBoardController : Controller
    {
       private static List<Blog> blogs = new List<Blog>();
       private static List<Product> products = new List<Product>();
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
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            
                if(product.CompId == 1)
                {
                    product.company = _db.companies.FirstOrDefault(p=>p.Id==1);
                }else if(product.CompId == 2)
                {
                    product.company = _db.companies.FirstOrDefault(p=>p.Id==2);
                }
            
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult viewproduct()
        {
            var product = _db.products.Include(p=>p.company).ToList();

            return View(product);
        } public IActionResult viewBlog()
        {
            return View(blogs);
        }public IActionResult DeleteBlog(int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = blogs.FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost ]
        public IActionResult DeleteBlog(Blog blog)
        {
            Blog blog2 = blogs.FirstOrDefault(b => b.Id == blog.Id);
            blogs.Remove(blog2);
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
            var b = blogs.FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Blog blog2 = blogs.FirstOrDefault(b => b.Id == blog.Id);
            blog2.Name=blog.Name;
            blog2.Description=blog.Description;
            if (blog.blogType.Id == 1)
            {
                blog.blogType.Name = "Comedy";
            }
            else if (blog.blogType.Id == 2)
            {
                blog.blogType.Name = "Romantic";
            }
            else
            {
                blog.blogType.Name = "Action";
            }
            blog2.blogType=blog.blogType;
            return RedirectToAction("viewBlog");
        }public IActionResult EditProduct(int?id)
        {
            var b = _db.products.Include(p=>p.company).FirstOrDefault(p=>p.Id==id);
            
            return View(b);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            
            if (product.company.Id == 1 || product.company.Id == 2)
            {
                product.company = _db.companies.FirstOrDefault(p => p.Id == product.company.Id);
            }
            
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
            int max = 0;
            blogs.ForEach(b =>
            {
                if (b.Id > max)
                {
                    max = b.Id;
                }
            });
            blog.Id = max+1;
            if (blog.blogType.Id == 1)
            {
                blog.blogType.Name = "Comedy";
            }else if (blog.blogType.Id == 2)
            {
                blog.blogType.Name = "Romantic";
            }
            else
            {
                blog.blogType.Name = "Action";
            }
            blogs.Add(blog);
            return RedirectToAction("Index");
        }
    




    }

}
