using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CatalogDbContext _context;

    public CategoriesController(CatalogDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Categories.ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound($"Category with ID {id} not found.");
        }
        return Ok(category);
    }

    public IActionResult Post([FromBody] Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Category category)
    {
        if (id != category.Id)
        {
            return BadRequest("Category ID mismatch.");
        }

        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null)
        {
            return NotFound($"Category with ID {id} not found.");
        }

        // Automatically copy values
        _context.Entry(existingCategory).CurrentValues.SetValues(category);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound($"Category with ID {id} not found.");
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
