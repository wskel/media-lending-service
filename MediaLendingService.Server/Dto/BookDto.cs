namespace MediaLendingService.Server.Dto;

public record BookDto(
    int Id,
    string Title,
    string Author,
    string Description,
    Uri CoverImage,
    string Publisher,
    DateOnly PublicationDate,
    LiteraryCategoryDto Category,
    string Isbn,
    int PageCount,
    bool IsCheckedOut = false
);