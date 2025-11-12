using books_web_api.Data.DTOs;
using books_web_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace books_web_api.Data.Services;

public class BooksService
{
    private AppDbContext _context;
    public BooksService(AppDbContext context)
    {
        _context = context;
    }

    public void AddBook(BookDTO book)
    {
        var _book = new Book()
        {
            Title = book.Title,
            Description = book.Description,
            IsRead = book.IsRead,
            DateRead = book.IsRead ? book.DateRead.Value : null,
            Rate = book.IsRead ? book.Rate.Value : null,
            Genre = book.Genre,
            CoverUrl = book.CoverUrl,
            Author = book.Author,
            DateAdded = DateTime.Now,
        };

        _context.Books.Add(_book);
        _context.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public Book GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book UpdateBookById(int id, BookDTO book)
    {
        var _book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (_book != null)
        {
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.DateRead = book.IsRead ? book.DateRead.Value : null;
            _book.Rate = book.IsRead ? book.Rate.Value : null;
            _book.Genre = book.Genre;
            _book.CoverUrl = book.CoverUrl;
            _book.Author = book.Author;

            _context.SaveChanges();
        }

        return _book;
    }

    public void DeleteBookById(int id)
    {
        var _book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (_book != null)
        {
            _context.Books.Remove(_book);
            _context.SaveChanges();
        }
    }
}