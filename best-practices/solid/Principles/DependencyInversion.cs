namespace Cookbook.BestPractices.SOLID.Principles;

// DIP: High-level modules should not depend on low-level modules
// Both should depend on abstractions
public interface IMessageService
{
    void Send(string message);
}

public class EmailService : IMessageService
{
    public void Send(string message) => Console.WriteLine($"Sending Email: {message}");
}

public class Notification
{
    private readonly IMessageService _mservice;

    public Notification(IMessageService service)
    {
        _mservice = service;
    }

    public void SendNotification(string message)
    {
        _mservice.Send(message);
    }
}

public static class DependencyInversion
{
    public static void Run()
    {
        Console.WriteLine("\n[Dependency Inversion Principle]");
        IMessageService service = new EmailService();
        var notification = new Notification(service);

        notification.SendNotification("Hello via Dependency Inversion Principle");
    }
}