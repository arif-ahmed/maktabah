using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public BooksController(CatalogDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        public IActionResult Get(Guid id)
        {
            var book = _context.Books.Find(id);
            return Ok(book);
        }
        public IActionResult Post([FromBody] Book book)
        {
            return Ok();
        }
        public IActionResult Put(Guid id, [FromBody] Book book)
        {
            return Ok();
        }
        public IActionResult Delete(Guid id) 
        {
            return Ok();
        }
    }
}
