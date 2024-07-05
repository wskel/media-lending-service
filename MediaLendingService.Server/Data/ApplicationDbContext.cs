using MediaLendingService.Server.Entities;
using MediaLendingService.Server.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace MediaLendingService.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<LiteraryCategoryEntity> LiteraryCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        DataSeeder.GenerateAndSeed(modelBuilder);
    }
}