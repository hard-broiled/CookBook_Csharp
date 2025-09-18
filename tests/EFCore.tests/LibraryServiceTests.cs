using Cookbook.Usage.EFCore.Data;
using Cookbook.Usage.EFCore.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EFCore.Tests;

public class LIbraryServiceTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options();

        return new AppDbContext(options);
    }

    [Fact]
    public async Task AddAuthorWithBooksAsync_ShouldAddAuthorAndBooks()
    {
        using var context = GetInMemoryDbContext();
        var service = new LibraryService(context);

        await service.AddAuthorWithBooksAsync("Test Author", new[] { "Book 1", "Book 2" });

        var authors = await service.GetAuthorsWithBooksAsync();

        Assert.Single(authors);
        Assert.Equal(2, authors.First().Books.Count);
    }
}