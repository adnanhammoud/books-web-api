using books_web_api.Data.DTOs;
using books_web_api.Data.Models;
using books_web_api.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace books_web_api.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : Controller
{
    public BooksService _booksService { get; set; }

    public BooksController(BooksService booksService)
    {
        _booksService = booksService;
    }
    
    [HttpPost("add-book")]
    public IActionResult AddBook([FromBody] BookDTO book)
    {
        _booksService.AddBook(book);
        return Ok();
    }

    [HttpGet("get-all-books")]
    public IActionResult GetAllBooks()
    {
        var books = _booksService.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("get-all-books-by-id/{id}")]
    public IActionResult GetBookById(int id)
    {
        var books = _booksService.GetBookById(id);
        return Ok(books);
    }

    [HttpPut("update-book/{id}")]
    public IActionResult UpdateBookById(int id, [FromBody] BookDTO book)
    {
        var updatedBook = _booksService.UpdateBookById(id, book);
        return Ok(updatedBook);
    }

    [HttpDelete("delete-book/{id}")]
    public IActionResult DeleteBookById(int id)
    {
        _booksService.DeleteBookById(id);
        return Ok();
    }
}