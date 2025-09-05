
namespace DotNetExamples.LanguageFeatures.Records
{

    public record Person(string FirstName, string LastName);

    /// <summary>
    /// Initial basic demonstration of utilizing a record with a value equality demonstration
    /// </summary>
    public static class Demo
    {
        public static void Run(string[] args)
        {

            var p1 = new Person("Jane", "Doe");
            var p2 = new Person("John", "Doe");
            var p3 = p1 with { LastName = "Smith" };

            Console.WriteLine($"p1: {p1}");
            Console.WriteLine($"p2: {p2}");
            Console.WriteLine($"p3: {p3}");
            Console.WriteLine($"p1 == p2?: {p1 == p2}");
            Console.WriteLine($"p1 == p3?: {p1 == p3}");
        }
    }
}