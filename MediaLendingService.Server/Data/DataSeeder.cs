using Bogus;
using MediaLendingService.Server.Entities;
using MediaLendingService.Server.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediaLendingService.Server.Data;

public static class DataSeeder
{
    private const int Seed = 12345;

    public static void GenerateAndSeed(ModelBuilder modelBuilder)
    {
        var roles = GenerateRoles();
        var categories = GenerateCategories();
        var books = GenerateBooks(categories);

        modelBuilder.Entity<ApplicationRole>().HasData(roles);
        modelBuilder.Entity<LiteraryCategoryEntity>().HasData(categories);
        modelBuilder.Entity<BookEntity>().HasData(books);
    }

    private static ApplicationRole[] GenerateRoles()
    {
        return new[]
        {
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
        };
    }

    private static LiteraryCategoryEntity[] GenerateCategories()
    {
        var categoryIds = 1;
        var names = new HashSet<string>();
        var faker = new Faker<LiteraryCategoryEntity>()
            .UseSeed(Seed)
            .RuleFor(c => c.Id, f => categoryIds++)
            .RuleFor(c => c.Name, f =>
            {
                var name = f.Commerce.Department();
                while (!names.Add(name))
                {
                    name = f.Commerce.Department();
                }

                return name;
            });

        return faker.Generate(10).ToArray();
    }

    private static BookEntity[] GenerateBooks(LiteraryCategoryEntity[] categories)
    {
        var bookIds = 1;
        var isbnSet = new HashSet<string>();
        var faker = new Faker<BookEntity>()
            .UseSeed(Seed)
            .RuleFor(b => b.Id, f => bookIds++)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.Author, f => f.Name.FullName())
            .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
            .RuleFor(b => b.CoverImage, f => new Uri(f.Image.PicsumUrl()))
            .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
            .RuleFor(b => b.PublicationDate, f => DateOnly.FromDateTime(f.Date.Past(10)))
            .RuleFor(b => b.CategoryId, f => f.PickRandom(categories).Id)
            .RuleFor(b => b.Isbn, f =>
            {
                var isbn = f.Commerce.Ean13();
                while (!isbnSet.Add(isbn))
                {
                    isbn = f.Commerce.Ean13();
                }

                return isbn;
            })
            .RuleFor(b => b.PageCount, f => f.Random.Int(100, 1000))
            .RuleFor(b => b.IsCheckedOut, f => f.Random.Bool());

        return faker.Generate(50).ToArray();
    }
}