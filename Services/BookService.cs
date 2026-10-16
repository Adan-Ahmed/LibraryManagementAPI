using Microsoft.EntityFrameworkCore;

public class BookService : IbookService    
{ 
    private readonly DbContext _context;

    public BookService(LibraryDbContext context) 
    {
        _context = context;
    }

}
