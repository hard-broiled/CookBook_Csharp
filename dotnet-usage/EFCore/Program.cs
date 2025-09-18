using Microsoft.EntityFrameworkCore;
using Cookbook.Usage.EFCore.Data;
using Cookbook.Usage.EFCore.Services;

namespace Cookbook.Usage.EFCore;

public class Program
{
    static async Task Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=db/library.db")
            .Options;

        using var context = new AppDbContext(options);
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        var libraryService = new LibraryService(context);

        // Seeding Data
        await libraryService.AddAuthorWithBooksAsync("Isaac Asimov",
        [
            "Foundation",
            "I, Robot"
        ]);

        await libraryService.AddAuthorWithBooksAsync("Frank Herbert",
        [
            "Dune",
            "Dune Messiah"
        ]);

        // Query Data
        var authors = await libraryService.GetAuthorsWithBooksAsync();
        foreach (var author in authors)
        {
            // Placeholder for providing retrieved data to requestor
            Console.WriteLine($"Author: {author.Name}");
            foreach (var book in author.Books)
            {
                Console.WriteLine($"\t- {book.Title}");
            }
        }
    }
}