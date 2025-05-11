using App.Practice2;

namespace AppTests.Practice2;

public class BenfordTests
{
    [TestCase("123 234 345 567 678 789 891 912 1000 00034 -122", new int[] { 3, 1, 1, 0, 1, 1, 1, 1, 1 })]
    [TestCase("0.111-0.111 -1.555 122a", new int[] { 4, 0, 0, 0, 1, 0, 0, 0, 0 })]
    [TestCase("00100, ,777.a999 aaa", new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0 })]
    [TestCase("00100 00100. ,777 .999 aaa", new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 1 })]
    [TestCase("", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    
    public void TestPasses_When_Result_Correct(string text, int[] expected)
    {
        var statistic = Benford.GetBenfordStatistics(text);
        Assert.That(statistic, Is.EqualTo(expected));
    }
}