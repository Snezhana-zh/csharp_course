using App.Practice2;
namespace AppTests.Practice2;

public class RequisitesTests
{
    [TestCase("540697278456", true)]
    [TestCase("54069727845", false)]
    [TestCase("543697278456", false)]
    public void TestPasses_When_Inn_Is_Valid(string inn, bool expected)
    {
        var actual = Requisites.IsValidInn(inn);
        Assert.That(actual, Is.EqualTo(expected));
    }
}