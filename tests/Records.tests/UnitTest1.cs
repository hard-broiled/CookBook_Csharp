using Cookbook.LanguageFeatures.Records;
using Xunit;

namespace Records.Tests;

public class PersonTests
{
    [Fact]
    public void Records_HaveValueEquality()
    {
        var p1 = new Person("Jane", "Doe");
        var p2 = new Person("Jane", "Doe");

        Assert.Equal(p1, p2);
    }

    [Fact]
    public void Records_InEquality_FromWith()
    {
        var p1 = new Person("Jane", "Doe");
        var p2 = p1 with { FirstName = "John" };

        Assert.NotEqual(p1, p2);
    }
}