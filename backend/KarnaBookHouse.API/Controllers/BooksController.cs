using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KarnaBookHouse.API.Data;

namespace KarnaBookHouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> SearchBooks(
        string search = "")
    {
        var books = await _context.Books
            .Where(b => b.Title.Contains(search))
            .ToListAsync();

        return Ok(books);
    }
}