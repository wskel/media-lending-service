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
        return Ok(await _bookService.GetBooksAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetBookAsync(int id)
    {
        return Ok(await _bookService.GetBookAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<BookDto>>> AddBooksAsync(IEnumerable<BookDto> books)
    {
        return Ok(await _bookService.AddBooksAsync(books));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BookDto>> UpdateBookAsync(int id, BookDto book)
    {
        return Ok(await _bookService.UpdateBookAsync(id, book));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBookAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return Ok();
    }
}