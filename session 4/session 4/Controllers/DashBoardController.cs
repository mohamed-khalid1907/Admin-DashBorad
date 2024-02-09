using Microsoft.AspNetCore.Mvc;
using session_4.Models;
namespace session_4.Controllers
{
    public class DashBoardController : Controller
    {
       private static List<Blog> blogs = new List<Blog>();
       private static List<Product> products = new List<Product>();
        
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
            int max = 0;
            products.ForEach(b =>
            {
                if (b.Id > max)
                {
                    max = b.Id;
                }
            });
            product.Id = max + 1;
            if (product.company.Id == 1)
            {
                product.company.Name = "nike";
            }
            else
            {
                product.company.Name = "addidas";
            }
            products.Add(product);
            return RedirectToAction("Index");
        }
         public IActionResult viewproduct()
        {
            return View(products);
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = products.FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost ]
        public IActionResult DeleteProduct(Product product)
        {
            Product pr2 = products.FirstOrDefault(b => b.Id == product.Id);
            products.Remove(pr2);
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = products.FirstOrDefault(b => b.Id == id);
            if (b == null)
            {
                return NotFound();   
            }
            return View(b);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            Product pr2 = products.FirstOrDefault(b => b.Id == product.Id);
            pr2.Name=product.Name;
            pr2.Description=product.Description;
            pr2.Price=product.Price;
            pr2.Quantity=product.Quantity;
            pr2.EnableSize=product.EnableSize;

            if (product.company.Id == 1)
            {
                product.company.Name = "nike";
            }
            else
            {
                product.company.Name = "addidas";
            }
            pr2.company = product.company;
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
