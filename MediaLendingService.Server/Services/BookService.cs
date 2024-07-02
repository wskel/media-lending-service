using MediaLendingService.Server.Data;
using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Services;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _dbContext;

    public BookService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<BookDto> GetBooks()
    {
        return _dbContext.Books
            .Include(b => b.Category)
            .Select(ToModel);
    }

    public BookDto? GetBook(int id)
    {
        var entity = _dbContext.Books
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);

        return entity != null ? ToModel(entity) : null;
    }

    public IEnumerable<BookDto> AddBooks(IEnumerable<BookDto> books)
    {
        var bookEntities = books.Select(ToEntity).ToArray();
        _dbContext.Books.AddRange(bookEntities);
        _dbContext.SaveChanges();

        return bookEntities.Select(ToModel);
    }

    public BookDto? UpdateBook(int id, BookDto book)
    {
        var bookEntity = _dbContext.Books
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);

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

        if (bookEntity.Category.Id != book.Category.Id)
        {
            // TO-DO
        }

        _dbContext.Books.Update(bookEntity);
        _dbContext.SaveChanges();
        return ToModel(bookEntity);
    }

    public bool DeleteBook(int id)
    {
        var bookEntity = _dbContext.Books.Find(id);
        if (bookEntity == null)
        {
            return false;
        }

        _dbContext.Books.Remove(bookEntity);
        _dbContext.SaveChanges();
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