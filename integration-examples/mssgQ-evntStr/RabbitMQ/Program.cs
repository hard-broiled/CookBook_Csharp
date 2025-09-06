
namespace Cookbook.Integrations.RabbitMQ;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            await Demo.RunAsync(args);
        }
        catch (Exception ex)
        {
            // Log unhandled exceptions
            Console.Error.WriteLine($"[FATAL] Unhandled exception: {ex}");
        }
    }
}