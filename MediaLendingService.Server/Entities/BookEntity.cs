using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Entities;

[Index(nameof(Title))]
[Index(nameof(Author))]
[Index(nameof(Isbn), IsUnique = true)]
[Index(nameof(PublicationDate))]
public record BookEntity
{
    [Key]
    public int Id { get; init; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public Uri CoverImage { get; set; } = null!;

    [Required]
    public string Publisher { get; set; } = null!;

    [Required]
    public DateOnly PublicationDate { get; set; }

    [ForeignKey("CategoryId")]
    [Required]
    public LiteraryCategoryEntity Category { get; set; } = null!;

    [Required]
    public string Isbn { get; set; } = null!;

    [Required]
    public int PageCount { get; set; }

    [Required]
    public bool IsCheckedOut { get; set; }

    // ReSharper disable once UnusedMember.Local
    private BookEntity() { }

    public BookEntity(
        int id,
        string title,
        string author,
        string description,
        Uri coverImage,
        string publisher,
        DateOnly publicationDate,
        LiteraryCategoryEntity category,
        string isbn,
        int pageCount,
        bool isCheckedOut)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        CoverImage = coverImage;
        Publisher = publisher;
        PublicationDate = publicationDate;
        Category = category;
        Isbn = isbn;
        PageCount = pageCount;
        IsCheckedOut = isCheckedOut;
    }
}