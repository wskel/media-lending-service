using MediaLendingService.Server.Data;
using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Services;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILiteraryCategoryService _categoryService;

    public BookService(ApplicationDbContext dbContext, ILiteraryCategoryService categoryService)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(categoryService);

        _dbContext = dbContext;
        _categoryService = categoryService;
    }

    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
        return await _dbContext.Books
            .Include(b => b.Category)
            .Select(entity => ToModel(entity))
            .ToListAsync();
    }

    public async Task<BookDto?> GetBookAsync(int id)
    {
        var entity = await _dbContext.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        return entity != null ? ToModel(entity) : null;
    }

    public async Task<IEnumerable<BookDto>> AddBooksAsync(IEnumerable<BookDto> books)
    {
        var bookEntities = books.Select(ToEntity).ToArray();
        await _dbContext.Books.AddRangeAsync(bookEntities);
        await _dbContext.SaveChangesAsync();

        return bookEntities.Select(ToModel);
    }

    public async Task<BookDto?> UpdateBookAsync(int id, BookDto book)
    {
        var bookEntity = await _dbContext.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (bookEntity == null)
        {
            return null;
        }

        bookEntity.Title = book.Title;
        bookEntity.Author = book.Author;
        bookEntity.Description = book.Description;
        bookEntity.CoverImage = book.CoverImage;
        bookEntity.Publisher = book.Publisher;
        bookEntity.PublicationDate = book.PublicationDate;
        bookEntity.Isbn = book.Isbn;
        bookEntity.PageCount = book.PageCount;
        bookEntity.IsCheckedOut = book.IsCheckedOut;

        var categoryId = book.Category.Id;
        if (bookEntity.Category.Id != categoryId)
        {
            var categoryEntity = await _categoryService.GetCategoryEntityAsync(categoryId);
            if (categoryEntity == null)
            {
                return null;
            }

            bookEntity.Category = categoryEntity;
        }

        _dbContext.Books.Update(bookEntity);
        await _dbContext.SaveChangesAsync();
        return ToModel(bookEntity);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var bookEntity = await _dbContext.Books.FindAsync(id);
        if (bookEntity == null)
        {
            return false;
        }

        _dbContext.Books.Remove(bookEntity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    private static BookDto ToModel(BookEntity entity) => new(
        entity.Id,
        entity.Title,
        entity.Author,
        entity.Description,
        entity.CoverImage,
        entity.Publisher,
        entity.PublicationDate,
        new LiteraryCategoryDto(entity.Category.Id, entity.Category.Name),
        entity.Isbn,
        entity.PageCount,
        entity.IsCheckedOut
    );

    private static BookEntity ToEntity(BookDto model) => new(
        model.Id,
        model.Title,
        model.Author,
        model.Description,
        model.CoverImage,
        model.Publisher,
        model.PublicationDate,
        new LiteraryCategoryEntity(model.Category.Id, model.Category.Name),
        model.Isbn,
        model.PageCount,
        model.IsCheckedOut
    );
}