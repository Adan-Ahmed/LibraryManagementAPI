using WebApplication1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{
    private readonly BookService _bookService;
    public BooksController(BookService bookService) 
    {
        _bookService = bookService;
    }

    [HttpGet]
    public List<Book> GetBooks() 
    {

        return _bookService.Books;

    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        if(_bookService.Books.Any(b => b.Id == book.Id)) 
        {
            return BadRequest("A book with this ID already exists.");
        }
        _bookService.Books.Add(book);
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
    {
        var book = _bookService.Books.FirstOrDefault(b => b.Id == id);

        if (book == null) 
        {
            return NotFound();
        }
            book.Title = updateBook.Title;
            book.Author = updateBook.Author;

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _bookService.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _bookService.Books.Remove(book);

        return NoContent();
    }



}
