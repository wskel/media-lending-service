using MediaLendingService.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MediaLendingService.Server.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public BookDto[] GetBooks()
    {
        var placeholderBook = GetPlaceholderBook();
        return new[] { placeholderBook };
    }

    [HttpGet("{id:int}")]
    public BookDto GetBook(int id)
    {
        return GetPlaceholderBook();
    }

    [HttpPost]
    public BookDto[] AddBook([FromBody] BookDto[] book)
    {
        var placeholderBook = GetPlaceholderBook();
        return new[] { placeholderBook };
    }

    [HttpPut("{id:int}")]
    public BookDto UpdateBook(int id, [FromBody] BookDto book)
    {
        return GetPlaceholderBook();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        return Ok();
    }

    private static BookDto GetPlaceholderBook()
    {
        var placeholderBook = new BookDto(
            Id: 1,
            Title: "title",
            Author: "author",
            Description: "",
            CoverImage: new Uri(""),
            Publisher: "",
            PublicationDate: DateOnly.FromDateTime(DateTime.Now),
            Category: new LiteraryCategoryDto(1, "Sci-fi"),
            Isbn: "",
            PageCount: 1
        );

        return placeholderBook;
    }
}