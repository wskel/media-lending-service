using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Entity;

[Index(nameof(Title))]
[Index(nameof(Author))]
[Index(nameof(Isbn), IsUnique = true)] 
[Index(nameof(PublicationDate))]
public record BookEntity
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public string Title { get; init; } = null!;

    [Required]
    public string Author { get; init; } = null!;

    [Required]
    public string Description { get; init; } = null!;

    [Required]
    public Uri CoverImage { get; init; } = null!;

    [Required]
    public string Publisher { get; init; } = null!;

    [Required]
    public DateOnly PublicationDate { get; init; }
    
    [ForeignKey("CategoryId")]
    [Required]
    public LiteraryCategoryEntity Category { get; init; } = null!;

    [Required]
    public string Isbn { get; init; } = null!;

    [Required]
    public int PageCount { get; init; }
    
    [Required]
    public bool IsCheckedOut { get; init; } = false;

    private BookEntity() { }
    
    public BookEntity(
        int id,
        string title,
        string author,
        string description,
        Uri coverImage,
        string publisher,
        LiteraryCategoryEntity category,
        string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        CoverImage = coverImage;
        Publisher = publisher;
        Category = category;
        Isbn = isbn;
    }
}