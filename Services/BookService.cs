namespace WebApplication1.Services;

public class BookService
{
    public List<Book> Books = new List<Book>();

    public BookService()
    {
        Book book1 = new Book
        {
            Id = 1,
            Title = "API Concept",
            Author = "Sir Rizwan"
        };
        Book book2 = new Book
        {
            Id = 2,
            Title = "C# Fundamentals",
            Author = "Sir Ali"
        };
        Book book3 = new Book
        {
            Id = 3,
            Title = "ASP.NET Core",
            Author = "Sir Shoiab"
        };


        Books.Add(book1);
        Books.Add(book2);
        Books.Add(book3);
    }
}