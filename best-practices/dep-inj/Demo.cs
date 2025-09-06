using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.BestPractices.DepInjDemo;

public interface IMessageService
{
    void Send(string message);
}

public class ConsoleMessageService : IMessageService
{
    public void Send(string message) => Console.WriteLine($"[Console] {message}");
}

public class Worker
{
    private readonly IMessageService _mservice;

    public Worker(IMessageService service)
    {
        _mservice = service;
    }

    public void DoWork()
    {
        _mservice.Send($"Dependency Injection Working Example Message. Time: {DateTime.UtcNow}");
    }
}

public static class Demo
{
    public static void Run(string[] args)
    {
        var services = new ServiceCollection();
        services.AddTransient<IMessageService, ConsoleMessageService>();
        services.AddTransient<Worker>();

        var provider = services.BuildServiceProvider();

        var worker = provider.GetRequiredService<Worker>();
        worker.DoWork();
    }
}