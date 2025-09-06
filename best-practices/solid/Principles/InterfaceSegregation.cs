namespace Cookbook.BestPractices.SOLID.Principles;

//ISP: Clients should not be forced to depend on methods they do not use
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public class MultiFunctionPrinter : IPrinter, IScanner
{
    public void Print() => Console.WriteLine("Printing Document...");
    public void Scan() => Console.WriteLine("Scanning Document...");
}

public class SimplePrinter : IPrinter
{
    public void Print() => Console.WriteLine("Simple Printing Document...");
}

public static class InterfaceSegregation
{
    public static void Run()
    {
        Console.WriteLine("\n[Interface Segregation Principle]");
        IPrinter printer = new SimplePrinter();
        printer.Print();

        var mfp = new MultiFunctionPrinter();
        mfp.Print();
        mfp.Scan();
    }
}