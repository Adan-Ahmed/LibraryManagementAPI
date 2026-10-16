using WebApplication1; // Agar Book doosre namespace mein hai
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services;

public interface IBookService
{
    Task<List<Book>> GetBooksAsync();
}