using App.Practice2;

namespace AppTests.Practice2;

public class FrequencyTests
{
    [Test]
    public void TestPasses_When_Result_Correct()
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
    public void TestPasses_When_Result_Correct_Empty()
    {
        string input = "a.";
        var expectedResult = new Dictionary<string, string>();
        var result = Frequency.FrequencyAnalysis(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TestPasses_When_Result_Correct_Words()
    {
        string input = "She stood up. Then she left.";
        var expectedResult = new Dictionary<string, string>
        {
            { "She", "stood" },
            { "stood", "up" },
            { "Then", "she" },
            { "she", "left" },
            { "She stood", "up" },
            { "Then she", "left" }
        };
        var result = Frequency.FrequencyAnalysis(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}