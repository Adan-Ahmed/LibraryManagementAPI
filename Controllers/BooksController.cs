using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<List<Book>> GetBooks() 
    {

        return await _bookService.GetBooksAsync();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookByID(int id) 
    {
        var book = await _bookService.Books.FirstOrDefaultAsync(b => b.Id == id);
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

        _bookService.Books.Add(book);
        await _bookService.SaveChangesAsync();
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
        var book = await _bookService.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) 
        {
            return NotFound();
        }
            book.Title = updateDto.Title;
            book.Author = updateDto.Author;

        await _bookService.SaveChangesAsync();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _bookService.Books.Remove(book);
        await _bookService.SaveChangesAsync();
        return NoContent();
    }

}
