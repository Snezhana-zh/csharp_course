using App.Practice2;

namespace AppTests.Practice2;

public class FrequencyTests
{
    [Test]
    public void TestPasses_When_Return_Correct_Frequencies()
    {
        string input = "a b c d. b c d. e b c a d.";
        var expectedResult = new Dictionary<string, string>
        {
            { "a", "b" },
            { "b", "c" },
            { "c", "d" },
            { "e", "b" },
            { "a b", "c" },
            { "b c", "d" },
            { "e b", "c" },
            { "c a", "d" }
        };
        var result = Frequency.FrequencyAnalysis(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TestPasses_When_Resulting_Dictionary_Empty()
    {
        string input = "a.";
        var expectedResult = new Dictionary<string, string>();
        var result = Frequency.FrequencyAnalysis(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TestPasses_When_Return_Correct_Frequencies_With_Other_Separators()
    {
        string input = "She, stood\tup\nthen she left.";
        var expectedResult = new Dictionary<string, string>
        {
            { "She", "stood" },
            { "stood", "up" },
            { "up", "then" },
            { "then", "she" },
            { "she", "left" },
            { "She stood", "up" },
            { "stood up", "then" },
            { "then she", "left" },
            { "up then", "she"}
        };
        var result = Frequency.FrequencyAnalysis(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}