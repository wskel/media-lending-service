using MediaLendingService.Server.Dto;

namespace MediaLendingService.Server.Services;

public interface IBookService
{
    Task<PagedResult<BookDto>> GetBooksAsync(
        bool useRandomOrdering = true,
        string? seed = null,
        string? searchString = null,
        int pageNumber = 1,
        int pageSize = 20);

    Task<BookDto> GetBookAsync(int id);

    Task<IEnumerable<BookDto>> AddBooksAsync(IEnumerable<BookDto> books);

    Task<BookDto> UpdateBookAsync(int id, BookDto book);

    Task DeleteBookAsync(int id);
}