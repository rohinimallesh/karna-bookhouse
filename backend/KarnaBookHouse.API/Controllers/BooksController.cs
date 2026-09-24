using KarnaBookHouse.API.DTOs;
using KarnaBookHouse.API.Models;
using KarnaBookHouse.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace KarnaBookHouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();

        return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
        {
            return NotFound($"Book with Id {id} not found.");
        }

        return Ok(book);
    }

    // GET: api/books/search?title=devops
    [HttpGet("search")]
    public async Task<IActionResult> SearchBooks(string title)
    {
        var books = await _bookService.GetAllBooksAsync();

        var result = books.Where(x =>
            x.Title.Contains(title,
            StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(result);
    }

    // POST: api/books
    [HttpPost]
    public async Task<IActionResult> AddBook(
        CreateBookDto createBookDto)
    {
        var book = new Book
        {
            Title = createBookDto.Title,
            Author = createBookDto.Author,
            Category = createBookDto.Category
        };

        await _bookService.AddBookAsync(book);

        return CreatedAtAction(
            nameof(GetBookById),
            new { id = book.Id },
            book);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(
        int id,
        UpdateBookDto updateBookDto)
    {
        var existingBook =
            await _bookService.GetBookByIdAsync(id);

        if (existingBook == null)
        {
            return NotFound($"Book with Id {id} not found.");
        }

        existingBook.Title = updateBookDto.Title;
        existingBook.Author = updateBookDto.Author;
        existingBook.Category = updateBookDto.Category;

        await _bookService.UpdateBookAsync(existingBook);

        return Ok(existingBook);
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var existingBook =
            await _bookService.GetBookByIdAsync(id);

        if (existingBook == null)
        {
            return NotFound($"Book with Id {id} not found.");
        }

        await _bookService.DeleteBookAsync(id);

        return Ok($"Book with Id {id} deleted successfully.");
    }
}