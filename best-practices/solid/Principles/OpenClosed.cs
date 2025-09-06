namespace Cookbook.BestPractices.SOLID.Principles;

/// <summary>
/// Example of OCP: Classes should be open for extension but closed for modification
/// </summary>
public abstract class Shape
{
    public abstract double Area();
}

public class Circle(double Radius) : Shape
{
    public double Radius { get; set; } = Radius;
    public override double Area() => Math.PI * Radius * Radius;
}

public class Square(double Side) : Shape
{
    public double Side { get; set; } = Side;
    public override double Area() => Side * Side;
}

public static class OpenClosed
{
    public static void Run()
    {
        Console.WriteLine("\n[Open/Closed Principle]");
        Shape[] shapes = { new Circle(1.25), new Square(2.5) };
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} area = {shape.Area():F2}");
        }
    }
}