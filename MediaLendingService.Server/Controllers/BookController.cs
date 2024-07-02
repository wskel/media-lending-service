using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLendingService.Server.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IEnumerable<BookDto> GetBooks()
    {
        return _bookService.GetBooks();
    }

    [HttpGet("{id:int}")]
    public ActionResult<BookDto> GetBook(int id)
    {
        var book = _bookService.GetBook(id);
        return book != null ? Ok(book) : NotFound();
    }

    [HttpPost]
    public IEnumerable<BookDto> AddBooks([FromBody] IEnumerable<BookDto> books)
    {
        return _bookService.AddBooks(books);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookDto> UpdateBook(int id, [FromBody] BookDto book)
    {
        var updatedBook = _bookService.UpdateBook(id, book);
        return updatedBook != null ? Ok(updatedBook) : NotFound();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteBook(int id)
    {
        return _bookService.DeleteBook(id) ? Ok() : NoContent();
    }
}