using MediaLendingService.Server.Dto;

namespace MediaLendingService.Server.Services;

public interface IBookService
{
    IEnumerable<BookDto> GetBooks();

    BookDto? GetBook(int id);

    IEnumerable<BookDto> AddBooks(IEnumerable<BookDto> books);

    BookDto? UpdateBook(int id, BookDto book);

    bool DeleteBook(int id);
}