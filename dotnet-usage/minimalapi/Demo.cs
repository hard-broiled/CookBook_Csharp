
namespace Cookbook.DotNetUsage.MinimalAPI;


public static class Demo
{
    public static void Run(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/time", () => DateTime.UtcNow);

        app.Run();
    }
}
