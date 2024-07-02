using MediaLendingService.Server.Entity;
using Microsoft.EntityFrameworkCore;
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace MediaLendingService.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<LiteraryCategoryEntity> LiteraryCategories { get; set; }
}