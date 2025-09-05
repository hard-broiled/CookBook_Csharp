
namespace DotNetExamples.LanguageFeatures.PatternMatching
{

    public abstract record Shape;

    public record Circle(double Radius) : Shape;
    public record Rectangle(double Width, double Height) : Shape;

    public static class Demo
    {
        public static void Run(string[] args)
        {
            Shape[] shapes = [new Circle(5), new Circle(2), new Rectangle(3, 4)];

            foreach (var shape in shapes)
            {
                string description = shape switch
                {
                    Circle(var r) when r > 3 => $"Large circle with radius {r}",
                    Circle(var r) => $"Small circle with radius {r}",
                    Rectangle(var w, var h) => $"Rectangle {w} x {h}",
                    _ => "Unknown shape"
                };

                Console.WriteLine(description);
            }
        }
    }
}