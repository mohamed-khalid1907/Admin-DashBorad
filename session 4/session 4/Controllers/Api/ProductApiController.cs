using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session_4.Data;
using session_4.Models.DTO;

namespace session_4.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController(ApplicationDbContext _db) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> Get(int id) { 
            if (id < 0)
            {
                return BadRequest(id);
            }
            var Product = _db.products.Include(e=>e.company).Select(m => new ProductDTO
            {
                company = m.company,
                Price = m.Price,
                Description = m.Description,
                Name = m.Name,
                CompId = m.CompId,
                Id = m.Id
            }).FirstOrDefault(e=>e.Id==id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);

        }
        [HttpGet]
        public ActionResult<List<ProductDTO>> Get()
        {

            var Product = _db.products.Include(e => e.company).Select(m => new ProductDTO
            {
                company = m.company,
                Price=m.Price,
                Description=m.Description,
                Name=m.Name,
                CompId=m.CompId,
                Id=m.Id
            }).ToList();
            return Ok(Product) ;

        }
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if ( !ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.products.Add(product);
            _db.SaveChanges(); 
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(id < 0)
            {
                return BadRequest(id);
            }
            var product = _db.products.Include(_ => _.company).FirstOrDefault(m=>m.Id==id);
            if (product == null)
            {
                return NotFound();
            }
            _db.Remove(product);
            _db.SaveChanges(); 
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Product Updatedproduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = _db.products.Include(e=>e.company).FirstOrDefault(e=>e.Id==Updatedproduct.Id);
            if (product == null)
            {
                return NotFound();
            }
            product.Description = Updatedproduct.Description;
            product.Name = Updatedproduct.Name;
            product.Price = Updatedproduct.Price;
            product.EnableSize = Updatedproduct.EnableSize;
            product.Quantity = Updatedproduct.Quantity;
            product.CompId  = Updatedproduct.CompId;
            _db.SaveChanges();
            return Ok();

        }

    }
}
