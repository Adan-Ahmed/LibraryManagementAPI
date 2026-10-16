
using WebApplication1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services;

public interface IBookService
{
    Task<List<Book>> GetBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, UpdateBookDto updateDto);
    Task<bool> DeleteBookAsync(int id);
}
