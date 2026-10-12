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

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book == null) 
        {
            return NotFound();
        }
            book.Title = updateBook.Title;
            book.Author = updateBook.Author;

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
