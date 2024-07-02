using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Entity;

[Index(nameof(Name), IsUnique = true)]
public record LiteraryCategoryEntity
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public string Name { get; init; } = null!;
    
    private LiteraryCategoryEntity() {}

    public LiteraryCategoryEntity(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }
}