namespace Cookbook.BestPractices.SOLID.Principles;

public class Invoice(decimal Amount)
{
    public decimal Amount { get; set;  } = Amount;
}

public class InvoicePrinter
{
    public void Print(Invoice invoice) => Console.WriteLine($"Printing Invoice: {invoice.Amount}");
}

public class InvoiceSaver
{
    public void Save(Invoice invoice) => Console.WriteLine($"Saving Invoice: {invoice.Amount}");
}

public static class SingleResponsibility
{
    public static void Run()
    {
        Console.WriteLine("\n[Single Responsibility Principle]");
        var invoice = new Invoice(3.142m);
        var printer = new InvoicePrinter();
        var saver = new InvoiceSaver();

        printer.Print(invoice);
        saver.Save(invoice);
    }
}