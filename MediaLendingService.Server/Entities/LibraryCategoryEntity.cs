using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Entities;

[Index(nameof(Name), IsUnique = true)]
public record LiteraryCategoryEntity
{
    [Key]
    public int Id { get; init; }

    [Required]
    public string Name { get; set; } = null!;

    // ReSharper disable once UnusedMember.Local
    private LiteraryCategoryEntity() { }

    public LiteraryCategoryEntity(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }
}