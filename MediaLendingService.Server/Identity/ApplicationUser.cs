using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Identity;

[Index(nameof(PreferredName))]
public class ApplicationUser : IdentityUser<Guid>
{
    [MaxLength(100)]
    public string? PreferredName { get; set; }
}