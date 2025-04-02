using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public AuthorsController(CatalogDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            List<Author> authors = _context.Authors.ToList();
            return Ok(authors);
        }

        public async Task<IActionResult> Get(Guid id)
        {
            Author? author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        public IActionResult Post([FromBody] Author author)
        {
            if (author == null) 
            {
                return BadRequest();
            }
            _context.Authors.Add(author);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Put(Guid id, [FromBody] Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            Author? existingAuthor = _context.Authors.Find(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            _context.Entry(existingAuthor).CurrentValues.SetValues(author);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Delete(Guid id)
        {
            Author? author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return Ok();
        }
    }
}
