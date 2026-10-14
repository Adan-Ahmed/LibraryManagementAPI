using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BooksController(LibraryDbContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Book>> GetBooks() 
    {

        return await _context.Books.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookByID(int id) 
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);

    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] CreateBookDto bookDto)
    {
        var book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction
            (
               nameof(GetBookByID),
               new {id = book.Id},
               book
            );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateDto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) 
        {
            return NotFound();
        }
            book.Title = updateDto.Title;
            book.Author = updateDto.Author;

        await _context.SaveChangesAsync();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
