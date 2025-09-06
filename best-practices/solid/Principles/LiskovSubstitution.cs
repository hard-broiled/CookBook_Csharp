namespace Cookbook.BestPractices.SOLID.Principles;

public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly() => Console.WriteLine("A Sparrow Flying...");
}

public class Ostrich : Bird
{
    public override void Fly() => throw new NotSupportedException("Ostriches can't fly");
}

public static class LiskovSubstitution
{
    public static void Run()
    {
        Console.WriteLine($"[Liskov Substitution Principle]");
        Bird bird = new Sparrow();
        bird.Fly();

        // Breaking LSP
        try
        {
            Bird ostrich = new Ostrich();
            ostrich.Fly();
        }
        catch(NotSupportedException nse)
        {
            Console.WriteLine($"LSP violation: {nse.Message}");
        }
    }
}