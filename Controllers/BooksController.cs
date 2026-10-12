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
    public List<Book> GetBooks() 
    {

        return _context.Books.ToList();

    }

    [HttpGet("{id}")]
    public IActionResult GetBookByID(int id) 
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);

    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookDto bookDto)
    {
        var book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author
        };

        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction
            (
               nameof(GetBookByID),
               new {id = book.Id},
               book
            );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto UpdateDto)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null) 
        {
            return NotFound();
        }
            book.Title = UpdateDto.Title;
            book.Author = UpdateDto.Author;

        _context.SaveChanges();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        _context.SaveChanges();
        return NoContent();
    }



}
