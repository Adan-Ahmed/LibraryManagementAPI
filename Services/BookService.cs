using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services;

public class BookService : IBookService
{
    private readonly LibraryDbContext _context;

    public BookService(LibraryDbContext context)
    {
        _context = context;
    }


    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id);
    }


    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> UpdateBookAsync(int id, UpdateBookDto updateDto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return null;
        }
        book.Title = updateDto.Title;
        book.Author = updateDto.Author;

        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }

}


