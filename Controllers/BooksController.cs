using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

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
        var book = await _bookService.GetBookByIdAsync(id);
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

        var createdBook = await _bookService.AddBookAsync(book);
        return CreatedAtAction
            (
               nameof(GetBookByID),
               new {id = createdBook.Id},
               createdBook
            );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateDto)
    {
        var book = await _bookService.UpdateBookAsync(id, updateDto);

        if (book == null) 
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var isDeleted = await _bookService.DeleteBookAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }


        return NoContent();
    }

}
