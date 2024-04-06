using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session_4.Data;
using session_4.Models;
using session_4.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace session_4.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApiController(ApplicationDbContext _db) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Blog> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest(id);
            }
            var blog = _db.blogs.Include(e => e.blogType).FirstOrDefault(e => e.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);

        }
        [HttpGet]
        public ActionResult<List<Blog>> Get()
        {

            var blog = _db.blogs.Include(e => e.blogType).ToList();
            return Ok(blog);

        }
        [HttpPost]
        public ActionResult<Blog> Post(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest(id);
            }
            var blog = _db.blogs.Include(e => e.blogType).FirstOrDefault(e => e.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            _db.Remove(blog);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Blog UpdatedBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var blog = _db.blogs.Include(e => e.blogType).FirstOrDefault(e => e.Id ==UpdatedBlog.Id);
            if (blog == null)
            {
                return NotFound();
            }
            blog.Name = UpdatedBlog.Name;
            blog.Description = UpdatedBlog.Description;
            blog.typeId = UpdatedBlog.typeId;
            _db.SaveChanges();
            return Ok();

        }

    }
}
