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

        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            (
                id: new Guid("c8d7e64a-7f5d-4e4e-a071-0fba45e8abc8"),
                name: "Customer",
                normalizedName: "CUSTOMER",
                concurrencyStamp: "90898a3a-0030-45ca-864c-655368c38764"
            ),
            new ApplicationRole
            (
                id: new Guid("ee3d910e-94ae-400b-b529-984520fa9639"),
                name: "Librarian",
                normalizedName: "LIBRARIAN",
                concurrencyStamp: "78ddc32f-51be-4500-ac3c-49e7ce5a0c23"
            )
        );
    }
}