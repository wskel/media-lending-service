using MediaLendingService.Server.Dto;

namespace MediaLendingService.Server.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();

    Task<BookDto> GetBookAsync(int id);

    Task<IEnumerable<BookDto>> AddBooksAsync(IEnumerable<BookDto> books);

    Task<BookDto> UpdateBookAsync(int id, BookDto book);

    Task DeleteBookAsync(int id);
}