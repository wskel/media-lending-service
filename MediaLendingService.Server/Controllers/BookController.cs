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
        ArgumentNullException.ThrowIfNull(bookService);
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetBookAsync(int id)
    {
        var book = await _bookService.GetBookAsync(id);
        return book != null ? Ok(book) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<BookDto>>> AddBooksAsync(IEnumerable<BookDto> books)
    {
        var addedBooks = await _bookService.AddBooksAsync(books);
        return Ok(addedBooks);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BookDto>> UpdateBookAsync(int id, BookDto book)
    {
        var updatedBook = await _bookService.UpdateBookAsync(id, book);
        return updatedBook != null ? Ok(updatedBook) : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBookAsync(int id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        return result ? Ok() : NoContent();
    }
}